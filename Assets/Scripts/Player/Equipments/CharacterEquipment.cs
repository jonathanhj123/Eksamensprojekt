using UnityEngine;
using System.Collections.Generic;

public class CharacterEquipment : MonoBehaviour
{
    [Header("Attachment points")]
    public Transform headSlot;
    public Transform bodySlot;
    public Transform handSlot;
    public Transform accessorySlot;

    private Dictionary<EquipSlot, ItemData> equippedItems = new();
    private Dictionary<EquipSlot, GameObject> ingameVisuals = new();

    public void Equip(ItemData item)
    {
        if (item == null) return;

        //unequips old item in slot
        UnEquip(item.equipSlot);

        //save new item in equipslot
        equippedItems[item.equipSlot] = item;

        //Spawn visuals for mainscreen
        Transform slotTransform = GetSlotTransform(item.equipSlot);
        if (slotTransform != null && item.prefab != null) 
        {
        GameObject instance = Instantiate(item.prefab, slotTransform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        ingameVisuals[item.equipSlot] = instance;
        }

        if (CharacterEquipmentData.Instance != null)
        {
            CharacterEquipmentData.Instance.SetItem(item);
        }

    }

    public void UnEquip(EquipSlot slot)
    {
        if (ingameVisuals.TryGetValue(slot, out GameObject instance))
        {
            Destroy(instance);
            ingameVisuals.Remove(slot);
        }

        if (equippedItems.ContainsKey(slot)) //Could be removed because by default .Remove(slot) already checks (returns true or false) if there is anything to remove, makes it easier to debug if needed
        {
            equippedItems.Remove(slot);
        }

        if (CharacterEquipmentData.Instance != null)
        {
            CharacterEquipmentData.Instance.ClearSlot(slot);
        }
    }

    public ItemData GetEquipped(EquipSlot slot)
    {
        equippedItems.TryGetValue(slot, out var item);
        return item;
    }
    private Transform GetSlotTransform(EquipSlot slot)
    {
        return slot switch
        {
            EquipSlot.Head => headSlot,
            EquipSlot.Body => bodySlot,
            EquipSlot.Hand => handSlot,
            EquipSlot.Accessory => accessorySlot,
            _ => null
        };
    }

    public void ApplyLoadout(PremadeSkin loadout) //For premade loadouts
{
    if (loadout.head)   Equip(loadout.head);
    if (loadout.body)   Equip(loadout.body);
    if (loadout.hand)   Equip(loadout.hand);
    if (loadout.accessory) Equip(loadout.accessory);
}

    public void ApplyFromData(CharacterEquipmentData data)
    {
        if (data == null) return;

        // Clear current visuals and logical state
        foreach (var item in ingameVisuals)
        {
            if (item.Value != null)
                Destroy(item.Value);
        }
        ingameVisuals.Clear();
        equippedItems.Clear();

        // Re-equip everything stored in persistent data
        foreach (var item in data.GetAll())
        {
            Equip(item.Value);
        }
    }

}
