using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");

        ItemCode itemCode = itemPickupable.GetItemCode();

        //ItemInventory itemInventory = itemPickupable.GetItemCtrl.GetItemInventory;
        if (this.playerCtrl.GetCurrentShip.GetInventory.AddItem(itemCode, 1))
        {
            itemPickupable.Picked();
        }
    }
}
