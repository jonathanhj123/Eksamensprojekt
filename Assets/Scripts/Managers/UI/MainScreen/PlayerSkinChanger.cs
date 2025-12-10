using UnityEngine;

public class PlayerSkinChanger : MonoBehaviour
{
    public CharacterEquipment characterEquipment;

    private void Awake()
    {
        if (CharacterEquipmentData.Instance != null)
        {
            characterEquipment.ApplyFromData(CharacterEquipmentData.Instance);
        }
    }
}
