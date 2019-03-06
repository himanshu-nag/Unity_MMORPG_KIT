using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PickUpObjectScript :MonoBehaviour {
    
    /// <summary>
    /// Add asset type here.
    /// </summary>
    public enum assetType{
        Health,
        Mana,
        Asset,
        none
    }
    [Tooltip("Make sure colliders are marked trigger")]
    public assetType _assetType;
    public Sprite PickUpGraphic;
    public int AssetValue;
    public string AssetName;
    public bool isConsumable;
    internal int regenValue;

    public virtual void OnTriggerStay(Collider obj)
    {
        if (obj.CompareTag("Player"))
            ShowPickUpButton();
        if (Input.GetKeyDown(PlayerManager.playerManager.itemPickUpKey))
        {
            PickUp(this);
            GameUIManager.gameUI.pickUpDescription.text = "";
        }
    }

    public virtual void OnTriggerExit(Collider obj)
    {
        if (obj.CompareTag("Player"))
            GameUIManager.gameUI.pickUpDescription.text = "";
    }

    public virtual void ShowPickUpButton()
    {
        if (InventoryData.InventoryCount >= InventoryData.MAXINVENTORYCOUNT)
        {
            //Change Inventory full text here.
            GameUIManager.gameUI.pickUpDescription.text = "Inventory full";
        }
        //Change pick up item text here. 
        else
            GameUIManager.gameUI.pickUpDescription.text = "Press " + PlayerManager.playerManager.itemPickUpKey + " to pick up " + name;
    }

    /// <summary>
    /// Picks up item.
    /// </summary>
    /// <param name="pickUp">Pick up.</param>
    public virtual void PickUp(PickUpObjectScript pickUp)
    {
        InventoryUIManager.InventoryUI.inventory.AddItem(pickUp);
    }
}
