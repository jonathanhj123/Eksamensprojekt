using UnityEngine;
using System.Collections.Generic;

public class CharacterEquipmentData : MonoBehaviour
{
public static CharacterEquipmentData Instance { get; private set; }

    private Dictionary<EquipSlot, ItemData> equippedItems = new();

    [Header("Seleced Loadout")]
    public PremadeLoadout currentLoadout;

    [Header("Weapon stats")]
    public ItemData currentWeapon;
    public int weaponTier = -1;

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

    public void SetLoadout(PremadeLoadout loadout)
    {
        currentLoadout = loadout;
    }

    public void SetWeapon(ItemData weapon, int tier)
    {
        currentWeapon = weapon;
        weaponTier = tier;
    }
}

