using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class LoadoutShopUI : MonoBehaviour
{
    [Header("Preview character in the menu")]
    public CharacterEquipment previewCharacter;

    [Header("UI")]
    public TMP_Text coinsText;
    public TMP_Text messageText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    public void PreviewLoadout(PremadeLoadout loadout)
    {
        if (previewCharacter == null || loadout == null) return;

        previewCharacter.ClearAll();
        previewCharacter.ApplyLoadout(loadout);

        if (CharacterEquipmentData.Instance != null &&
            CharacterEquipmentData.Instance.currentWeapon != null)
        {
            previewCharacter.ApplyWeapon(CharacterEquipmentData.Instance.currentWeapon);
        }
    }

      public void TryToBuyLoadout(PremadeLoadout loadout)
    {
        ClearMessage();
        if (loadout == null) return;

        if (GameData.Instance == null)
        {
            StartCoroutine(ShowMessage("ERROR: Your coins have vanished into the abyss for now."));
            return;
        }

        if (!GameData.Instance.CanAfford(loadout.price))
        {
            StartCoroutine(ShowMessage("You're too broke for this."));
            return;
        }

        GameData.Instance.SpendCoins(loadout.price);
        
        if (CharacterEquipmentData.Instance != null)
        {
            CharacterEquipmentData.Instance.SetLoadout(loadout);
        }

        StartCoroutine(ShowMessage("Outfit purchased!"));
    }

        private void UpdateCoinsUI()
    {
        if (coinsText != null && GameData.Instance != null)
        {
            coinsText.text = "Coins: " + GameData.Instance.NewTotalCoins;
        }
    }

     private void ClearMessage()
    {
        messageText.text = "";
    }

    private IEnumerator ShowMessage(string msg) {
        if (messageText != null)
            messageText.text = msg;
            yield return new WaitForSeconds(3f);
            ClearMessage();
    }
}
