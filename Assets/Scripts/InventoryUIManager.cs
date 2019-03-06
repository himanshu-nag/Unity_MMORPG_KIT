using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour {

    public static InventoryUIManager InventoryUI;

    public GameObject emptyItem;

    internal InventoryManager inventory;

    public List<Image> itemsHUD;

	private void Awake()
	{
        if (InventoryUI != null)
            Destroy(gameObject);

        InventoryUI = this;

        inventory = new InventoryManager();
        itemsHUD = new List<Image>(inventory.inventorySize);
	}

	private void Start()
	{
        for (int i = 0; i < inventory.inventorySize; i++)
        {
            GameObject TempItem = Instantiate(emptyItem, transform);
            itemsHUD.Add(TempItem.GetComponent<Image>());
        }
    }

    public void SetItemInventory(PickUpObjectScript pickUpObject, int currentIndex)
    {
        
        if(currentIndex<inventory.inventorySize)
        {
            itemsHUD[currentIndex].sprite = pickUpObject.PickUpGraphic;
        }
    }

    //TODO: Setup object pooling
    public void ConsumedItemUpdate(int _key)
    {
        itemsHUD[_key-1].sprite = null;
    }
}
