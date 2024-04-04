using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.playerCtrl.CurrentShip.Inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
