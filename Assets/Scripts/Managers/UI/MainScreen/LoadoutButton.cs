using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class LoadoutButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [Header("Data")]
    public PremadeLoadout loadout;

    [Header("References")]
    public TMP_Text loadoutPriceTMP;

    public LoadoutShopUI loadoutShop;

    private void Awake()
    {
        RefreshPrice();
    }

    // Hover = preview
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (loadoutShop != null && loadout != null)
        {
            loadoutShop.PreviewLoadout(loadout);
        }
    }

    // Click = attempt purchase
    public void OnPointerClick(PointerEventData eventData)
    {
        if (loadoutShop != null && loadout != null)
        {
            loadoutShop.OnLoadoutClicked(loadout);
            RefreshPrice();
        }
    }

    public void RefreshPrice()
    {
        if (loadout == null) return;

        bool isOwned = CharacterEquipmentData.Instance != null &&
                       CharacterEquipmentData.Instance.IsLoadoutOwned(loadout);

        bool isEquipped = CharacterEquipmentData.Instance != null &&
                          CharacterEquipmentData.Instance.currentLoadout == loadout;

        if (loadoutPriceTMP != null)
            if (isEquipped) 
            {
                loadoutPriceTMP.text = "Equipped";
            }
            if (isOwned) 
            {
                loadoutPriceTMP.text = "Owned";
            }
            else 
            { 
                loadoutPriceTMP.text = loadout.price.ToString();
            }
    }
}

