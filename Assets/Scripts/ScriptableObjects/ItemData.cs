using UnityEngine;

[CreateAssetMenu(menuName = "Item")]
public class ItemData : ScriptableObject
{
    [Header("Identity")]
    public string id;
    public string displayName;
    [TextArea] public string description;

    [Header("Inventory Data")]
    public ItemCategory category;
    public EquipSlot equipSlot;

    [Header("Visuals")]
    public Sprite icon;
    public GameObject prefab;
}
