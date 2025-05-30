using Unity.VisualScripting;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform cropCountainerParent;
    [SerializeField] private UICropContainer uiCropContainerPrefab;

    public void Configure(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();

        for (int i = 0; i < items.Length; i++)
        {
            UICropContainer cropContainerInstance = Instantiate(uiCropContainerPrefab, cropCountainerParent);

            Sprite cropIcon = DataManager.instance.GetCropIconFromCropType(items[i].cropType);

            cropContainerInstance.Configure(cropIcon, items[i].amount);
        }
    }

    public void UpdateDisplay(Inventory inventory)
    {
        InventoryItem[] items = inventory.GetInventoryItems();

        for (int i = 0; i < items.Length; i++)
        {
            UICropContainer containerInstance;
            if (i < cropCountainerParent.childCount)
            {
                containerInstance = cropCountainerParent.GetChild(i).GetComponent<UICropContainer>();
                containerInstance.gameObject.SetActive(true);
            }
            else
                containerInstance = Instantiate(uiCropContainerPrefab, cropCountainerParent);
                
            
            Sprite cropIcon = DataManager.instance.GetCropIconFromCropType(items[i].cropType);
            containerInstance.Configure(cropIcon, items[i].amount);
        }

        int remaningContainers = cropCountainerParent.childCount - items.Length;
        if (remaningContainers <= 0)
            return;
        
        for (int i = 0; i < remaningContainers; i++)
            cropCountainerParent.GetChild(items.Length + i).gameObject.SetActive(false);
    }
}
