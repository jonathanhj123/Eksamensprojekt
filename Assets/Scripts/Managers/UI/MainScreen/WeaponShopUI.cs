using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class WeaponShopUI : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Preview character in menu")]
    [SerializeField] private CharacterEquipment previewCharacter;

    [Header("Weapon tiers (0 = Glock, 1 = Deagle")]
    [SerializeField] private ItemData[] weaponTiers;
    [SerializeField] private int[] upgradeCosts; 

    [Header("UI")]
    [SerializeField] TMP_Text coinsText;
    [SerializeField] private TMP_Text messageText;
    [SerializeField] private TMP_Text upgradeInfoText;


    private void Start()
    {
        RefreshUpgradeInfo();
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

        // Remove skins if you're previewing and show currently equipped loadout.
        previewCharacter.ClearAll();
        if (CharacterEquipmentData.Instance != null)
        {
            if (CharacterEquipmentData.Instance.currentLoadout != null)
                previewCharacter.ApplyLoadout(CharacterEquipmentData.Instance.currentLoadout);
        }

        // Show next weapon
        previewCharacter.ApplyWeapon(nextWeapon);
    }

    private void TryUpgradeWeapon()
    {
        int nextTier= GetNextTier();
        int cost = upgradeCosts[nextTier];

        if (nextTier == -1)
        {
            StartCoroutine(ShowMessage("Weapon is already at max level."));
            return;
        }

        if (GameData.Instance == null || CharacterEquipmentData.Instance == null)
        {
            StartCoroutine(ShowMessage("Missing GameData or CharacterEquipmentData."));
            return;
        }

        if (!GameData.Instance.CanAfford(cost))
        {
            StartCoroutine(ShowMessage("Not enough coins to upgrade weapon."));
            return;
        }

        // Upgrade if cleared all checks
        ItemData nextWeapon = weaponTiers[nextTier];

        GameData.Instance.SpendCoins(cost);
        UpdateCoinsUI();

        CharacterEquipmentData.Instance.SetWeapon(nextWeapon, nextTier);

        // Update preview to show new gøb
        if (previewCharacter != null)
        {
            previewCharacter.ClearAll();
            if (CharacterEquipmentData.Instance.currentLoadout != null)
                previewCharacter.ApplyLoadout(CharacterEquipmentData.Instance.currentLoadout);

            previewCharacter.ApplyWeapon(nextWeapon);
        }
        StartCoroutine(ShowMessage("Weapon upgraded to " + nextWeapon.displayName + "!"));
    }

    private void RefreshUpgradeInfo()
    {
        if (upgradeInfoText == null)
            return;

        int nextIndex = GetNextTier();
        if (nextIndex == -1)
        {
            upgradeInfoText.text = "Weapon at MAX level";
            return;
        }

        ItemData nextWeapon = weaponTiers[nextIndex];
        int cost = upgradeCosts[nextIndex];

        upgradeInfoText.text = "Upgrade to " + nextWeapon.displayName + "  - " + cost + " coins";
    }
    
     private void UpdateCoinsUI()
    {
        if (coinsText != null && GameData.Instance != null)
        {
            coinsText.text = "Coins: " + GameData.Instance.NewTotalCoins;
        }
    }

      private IEnumerator ShowMessage(string msg) {
        if (messageText != null)
            messageText.text = msg;
            yield return new WaitForSeconds(3f);
            ClearMessage();
    }

      private void ClearMessage()
    {
        messageText.text = "";
    }
}
