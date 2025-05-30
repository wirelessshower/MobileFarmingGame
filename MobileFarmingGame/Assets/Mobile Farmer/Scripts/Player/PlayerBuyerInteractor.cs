using System;
using UnityEngine;

public class PlayerBuyerInteractor : MonoBehaviour
{
    [Header("Elements")]
    [SerializeField] private InventoryManager inventoryManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Buyer"))
            SellCrios();
    }

    private void SellCrios()
    {
        Inventory inventory = inventoryManager.GetInventory();
        InventoryItem[] items = inventory.GetInventoryItems();

        int coinsEarned = 0;

        for (int i = 0; i < items.Length; i++)
        {
            // Calculate the Ernings 
            int itemPrice = DataManager.instance.GetCropPriceFromCrop(items[i].cropType);
                            
            coinsEarned += itemPrice * items[i].amount;
        }

        // Give Coins to Player
        CashManager.instance.AddCoins(coinsEarned);


        // Clear Inventory
        inventoryManager.ClearInventory();
    }
}
