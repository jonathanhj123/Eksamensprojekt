using UnityEngine;

[CreateAssetMenu(fileName = "PremadeLoadout", menuName = "PremadeLoadout")]
public class PremadeLoadout : ScriptableObject
{
    public ItemData head;
    public ItemData body;
    public ItemData lefthand;
    
    [Header("Shop")]
    public int price;
}
