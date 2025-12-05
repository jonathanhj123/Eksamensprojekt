using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LoadoutShopUI : MonoBehaviour
{
    [Header("Preview character in the menu")]
    public CharacterEquipment previewCharacter;

    [Header("UI")]
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
            ShowMessage("ERROR: Your coins have vanished into the abyss for now.");
            return;
        }

        if (!GameData.Instance.CanAfford(loadout.price))
        {
            ShowMessage("You're too broke for this.");
            return;
        }

        GameData.Instance.SpendCoins(loadout.price);
        
        if (CharacterEquipmentData.Instance != null)
        {
            CharacterEquipmentData.Instance.SetLoadout(loadout);
        }

        ShowMessage("Outfit purchased!");
    }

    
    private void ShowMessage(string msg)
    {
        if (messageText != null)
            messageText.text = msg;
    }

     private void ClearMessage()
    {
        ShowMessage("");
    }
}
