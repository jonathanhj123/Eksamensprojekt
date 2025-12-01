using UnityEngine;
using System.Collections.Generic;

public class CharacterEquipmentData : MonoBehaviour
{
public static CharacterEquipmentData Instance { get; private set; }

    private Dictionary<EquipSlot, ItemData> equippedItems = new();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetItem(ItemData item)
    {
        if (item == null) return;

        equippedItems[item.equipSlot] = item;
    }

    public void ClearSlot(EquipSlot slot)
    {
        equippedItems.Remove(slot);
    }

    public ItemData GetItem(EquipSlot slot)
    {
        equippedItems.TryGetValue(slot, out var item);
        return item;
    }

    public IEnumerable<KeyValuePair<EquipSlot, ItemData>> GetAll()
    {
        return equippedItems;
    }
}

