using UnityEngine;

[CreateAssetMenu(fileName = "PremadeLoadout", menuName = "Scriptable Objects/PremadeLoadout")]
public class PremadeLoadout : ScriptableObject
{
    public ItemData head;
    public ItemData body;
    public ItemData lefthand;
    public ItemData accessory;
    public ItemData weapon;
}
