using UnityEngine;

[CreateAssetMenu(fileName = "CropData", menuName = "Scriptable Objects/CropData", order = 0)]
public class CropData : ScriptableObject
{
    [Header("settings")]
    public Crop cropPrefub;
    public CropType cropType;
    public Sprite Icon;
    public int price;
}
