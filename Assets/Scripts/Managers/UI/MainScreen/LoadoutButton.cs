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

    private void RefreshPrice()
    {
        if (loadout == null) return;

        if (loadoutPriceTMP != null) {
            loadoutPriceTMP.text = loadout.price.ToString();
        }
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
            loadoutShop.TryToBuyLoadout(loadout);
        }
    }
}

