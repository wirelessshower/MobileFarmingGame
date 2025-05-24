using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    [SerializeField] List<InventoryItem> items = new List<InventoryItem>();


    public void CropHarvestedCallback(CropType cropType)
    {
        Debug.Log(cropType + "zarezali");
    }
}
