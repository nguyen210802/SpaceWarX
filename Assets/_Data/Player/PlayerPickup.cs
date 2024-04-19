using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : PlayerAbstract
{
    public virtual void ItemPickup(ItemPickupable itemPickupable)
    {
        Debug.Log("ItemPickup");

        ItemInventory itemInventory = itemPickupable.GetItemCtrl.GetItemInventory;
        if (this.playerCtrl.GetCurrentShip.GetInventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
