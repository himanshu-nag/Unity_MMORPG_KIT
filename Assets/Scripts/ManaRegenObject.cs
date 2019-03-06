using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaRegenObject : PickUpObjectScript
{

    public int ManaRegenValue;

    private void Awake()
    {
        regenValue = ManaRegenValue;
    }

    public override void OnTriggerStay(Collider obj)
    {
        base.OnTriggerStay(obj);
    }

    public override void OnTriggerExit(Collider obj)
    {
        base.OnTriggerExit(obj);
    }

    public override void ShowPickUpButton()
    {
        base.ShowPickUpButton();
    }

    public override void PickUp(PickUpObjectScript pickUp)
    {
        if (InventoryData.InventoryCount < InventoryData.MAXINVENTORYCOUNT)
        {
            base.PickUp(pickUp);
            gameObject.SetActive(false);
        }
    }

}