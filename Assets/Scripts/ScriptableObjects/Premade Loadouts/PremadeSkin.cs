using UnityEngine;

[CreateAssetMenu(fileName = "PremadeSkin", menuName = "Scriptable Objects/PremadeSkin")]
public class PremadeSkin : ScriptableObject
{
    public ItemData head;
    public ItemData body;
    public ItemData hand;
    public ItemData accessory;
}
