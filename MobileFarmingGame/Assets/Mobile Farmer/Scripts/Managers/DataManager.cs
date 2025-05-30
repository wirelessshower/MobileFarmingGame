using Unity.VisualScripting;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;

    [Header(" Data ")]
    [SerializeField] private CropData[] cropData;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public Sprite GetCropIconFromCropType(CropType type)
    {
        for (int i = 0; i < cropData.Length; i++)
        {
            if (cropData[i].cropType == type)
                return cropData[i].Icon;
        }
        Debug.LogError("No CropData found of that type");
        return null;

    }

    public int GetCropPriceFromCrop(CropType cropType)
    {
        for (int i = 0; i < cropData.Length; i++)
        {
            if (cropData[i].cropType == cropType)
                return cropData[i].price;
        }
        Debug.LogError("No CropData found of that type");
        return 0;
    }
}