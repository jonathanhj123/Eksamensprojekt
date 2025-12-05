using UnityEngine;
using UnityEngine.EventSystems;

public class LoadoutButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    public PremadeLoadout loadout;
    public LoadoutShopUI loadoutShop;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (loadoutShop != null && loadout != null)
        {
        loadoutShop.PreviewLoadout(loadout);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (loadoutShop != null && loadout != null)
        {
        loadoutShop.TryToBuyLoadout(loadout);
        }
    }
}
