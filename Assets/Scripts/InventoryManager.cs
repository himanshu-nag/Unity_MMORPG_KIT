using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager {
    public Dictionary<int, PickUpObjectScript> item;
    public int inventorySize = 12;
    internal int currentIndex = 1;
    private List<int> emptyItems;
    public InventoryManager()
    {
        item = new Dictionary<int, PickUpObjectScript>();
        emptyItems = new List<int>();
    }

    public void AddItem(PickUpObjectScript pickUpObject)
    {
        int temp;

        if (emptyItems.Count > 0)
        {
            temp = emptyItems[0];
            emptyItems.Remove(0);
        }
        else
        {
            temp = currentIndex;
            currentIndex += 1;
        }
        item.Add(temp, pickUpObject);
        InventoryData.InventoryCount += 1; 
        InventoryUIManager.InventoryUI.SetItemInventory(pickUpObject,temp-1);
    }

    public void UseItem(int _key)
    {
        if (_key <= currentIndex && item[_key] != null)
        {
            if (item[_key].isConsumable)
            {
                ConsumeItem(_key);
            }
            item.Remove(_key);
            emptyItems.Add(_key);
            InventoryData.InventoryCount -=1;
            InventoryUIManager.InventoryUI.ConsumedItemUpdate(_key);
        }
        else
        {
            throw null;
        }
    }

    /// <summary>
    /// Add Asset type functions here.
    /// </summary>
    /// <param name="_key">Key.</param>
    private void ConsumeItem(int _key)
    {
        switch (item[_key]._assetType)
        {
            case PickUpObjectScript.assetType.Health:
                var regenHealthTotal = item[_key].regenValue + PlayerManager.playerManager.playerHealth;
                if (regenHealthTotal > PlayerManager.playerManager.playerhealthMAX)
                    PlayerManager.playerManager.playerHealth = PlayerManager.playerManager.playerhealthMAX;
                else
                    PlayerManager.playerManager.playerHealth += regenHealthTotal;

                GameUIManager.gameUI.UpdatePlayerHealthBar();
                break;

            case PickUpObjectScript.assetType.Mana:
                var regenManaTotal = item[_key].regenValue + PlayerManager.playerManager.playerMana;
                if (regenManaTotal > PlayerManager.playerManager.playerManaMAX)
                    PlayerManager.playerManager.playerMana = PlayerManager.playerManager.playerManaMAX;
                else
                    PlayerManager.playerManager.playerMana += regenManaTotal;
                GameUIManager.gameUI.UpdatePlayerManaBar();
                break;

            default:
                break;
        }
    }
}
