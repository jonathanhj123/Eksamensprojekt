using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class WeaponShopUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Preview character in menu")]
    public CharacterEquipment previewCharacter;

    [Header("Weapon tiers (0 = Glock, 1 = Deagle, 2 = AK, etc.)")]
    public ItemData[] weaponTiers;
    public int[] upgradeCosts; 

    [Header("UI")]
    public TMP_Text messageText;


    private void Start()
    {

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        PreviewNextWeapon();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TryUpgradeWeapon();
    }

    private int GetCurrentTier()
    {
        if (CharacterEquipmentData.Instance == null) return -1;
        return CharacterEquipmentData.Instance.weaponTier;
    }

    private int GetNextTier()
    {
        int current = GetCurrentTier();
        int next = current + 1;
        if (weaponTiers == null || next < 0 || next >= weaponTiers.Length)
            return -1; // no next tier
        return next;
    }

    private void PreviewNextWeapon()
    {
        int nextTier = GetNextTier();
        if (nextTier == -1) return;

        ItemData nextWeapon = weaponTiers[nextTier];
        if (previewCharacter == null || nextWeapon == null) return;

        // Start from current cosmetics + current weapon from data
        previewCharacter.ClearAll();
        if (CharacterEquipmentData.Instance != null)
        {
            if (CharacterEquipmentData.Instance.currentLoadout != null)
                previewCharacter.ApplyLoadout(CharacterEquipmentData.Instance.currentLoadout);
        }

        // Show next weapon tier
        previewCharacter.ApplyWeapon(nextWeapon);
    }

    private void TryUpgradeWeapon()
    {
        int nextTier= GetNextTier();
        if (nextTier == -1)
        {
            ShowMessage("Weapon is already at max level.");
            return;
        }

        if (GameData.Instance == null || CharacterEquipmentData.Instance == null)
        {
            ShowMessage("Missing GameData or CharacterEquipmentData.");
            return;
        }

        int cost = upgradeCosts[nextTier];

        if (!GameData.Instance.CanAfford(cost))
        {
            ShowMessage("Not enough coins to upgrade weapon.");
            return;
        }

        // Upgrade
        ItemData nextWeapon = weaponTiers[nextTier];

        GameData.Instance.SpendCoins(cost);

        CharacterEquipmentData.Instance.SetWeapon(nextWeapon, nextTier);

        // Update preview to show new gøb
        if (previewCharacter != null)
        {
            previewCharacter.ClearAll();
            if (CharacterEquipmentData.Instance.currentLoadout != null)
                previewCharacter.ApplyLoadout(CharacterEquipmentData.Instance.currentLoadout);

            previewCharacter.ApplyWeapon(nextWeapon);
        }
        ShowMessage($"Weapon upgraded to {nextWeapon.displayName}!");
    }

     private void ShowMessage(string msg)
    {
        if (messageText != null)
            messageText.text = msg;
    }
}
