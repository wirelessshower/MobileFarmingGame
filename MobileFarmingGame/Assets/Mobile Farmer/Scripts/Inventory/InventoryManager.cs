using System;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(InventoryDisplay))]
public class InventoryManager : MonoBehaviour
{


    private InventoryDisplay inventoryDisplay;
    private Inventory inventory;
    private string dataPath;

    void Start()
    {
        dataPath = Application.dataPath + "/inventoryData.txt";
        
        LoadInventory();
        ConfigureInventoryDisplay();        

        CropTile.onCropHarvested += CropHarvestedCallback;
    }


    void OnDestroy()
    {
        CropTile.onCropHarvested -= CropHarvestedCallback;
    }

    private void CropHarvestedCallback(CropType cropType)
    {
        inventory.CropHarvestedCallback(cropType);

        inventoryDisplay.UpdateDisplay(inventory);

        SaveInventory();
    }

    private void ConfigureInventoryDisplay()
    {
        inventoryDisplay = GetComponent<InventoryDisplay>();
        inventoryDisplay.Configure(inventory);
    }

    [NaughtyAttributes.Button]
    public void ClearInventory()
    {
        inventory.Clear();
        inventoryDisplay.UpdateDisplay(inventory);
        SaveInventory();        
    }

    private void LoadInventory()
    {

        string data = "";
        if (File.Exists(dataPath))
        {
            data = File.ReadAllText(dataPath);
            inventory = JsonUtility.FromJson<Inventory>(data);

            inventory ??= new Inventory();
        }
        else
        {
            File.Create(dataPath);
            inventory = new Inventory();
        }
    }

    private void SaveInventory()
    {
        string data = JsonUtility.ToJson(inventory, true);
        File.WriteAllText(Application.dataPath + "/inventoryData.txt", data);
    }

    public Inventory GetInventory()
    {
        return inventory;
    }
}
