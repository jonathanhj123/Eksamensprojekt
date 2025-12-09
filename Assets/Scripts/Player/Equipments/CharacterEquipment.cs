using UnityEngine;
using System.Collections.Generic;

public class CharacterEquipment : MonoBehaviour
{
    [Header("Attachment points")]
    public Transform headSlot;
    public Transform bodySlot;
    public Transform leftHandSlot;
    public Transform accessorySlot;
    public Transform weaponSlot;

    private Dictionary<EquipSlot, GameObject> ingameVisuals = new();


    public void ApplyLoadout(PremadeLoadout loadout)
    {
        if (loadout == null) return;

        if (loadout.head != null) EquipItem(loadout.head);
        if (loadout.body != null) EquipItem(loadout.body);
        if (loadout.lefthand != null) EquipItem(loadout.lefthand);
        if (loadout.accessory != null) EquipItem(loadout.accessory);
    }

    public void ApplyWeapon(ItemData weapon)
    {
        if (weapon == null)
        {
            UnEquip(EquipSlot.Weapon);
            return;
        }

        EquipItem(weapon);
    }


    public void ApplyFromData(CharacterEquipmentData data)
    {
        if (data == null) return;

        ClearAll();

        if (data.currentLoadout != null)
        {
            ApplyLoadout(data.currentLoadout);
        }

        if (data.currentWeapon != null)
        {
            ApplyWeapon(data.currentWeapon);
        }
    }

    public void ClearAll()
    {
        foreach (var pair in ingameVisuals)
        {
            if (pair.Value != null)
                Destroy(pair.Value);
        }
        ingameVisuals.Clear();
    }


    public void EquipItem(ItemData item)
    {
        if (item == null) return;

        //unequips old item in slot
        UnEquip(item.equipSlot);

        //Spawn visuals
        Transform slotTransform = GetSlotTransform(item.equipSlot);
        if (slotTransform != null && item.prefab != null) 
        {
        GameObject instance = Instantiate(item.prefab, slotTransform);
        instance.transform.localPosition = Vector3.zero;
        instance.transform.localRotation = Quaternion.identity;
        ingameVisuals[item.equipSlot] = instance;
        }
    }



    public void UnEquip(EquipSlot slot)
    {
        if (ingameVisuals.TryGetValue(slot, out GameObject instance))
        {
            Destroy(instance);
            ingameVisuals.Remove(slot);
        }
    }



    private Transform GetSlotTransform(EquipSlot slot)
    {
        return slot switch
        {
            EquipSlot.Head      => headSlot,
            EquipSlot.Body      => bodySlot,
            EquipSlot.LeftHand  => leftHandSlot,
            EquipSlot.Accessory => accessorySlot,
            EquipSlot.Weapon    => weaponSlot,
            _ => null
        };
    }

}
