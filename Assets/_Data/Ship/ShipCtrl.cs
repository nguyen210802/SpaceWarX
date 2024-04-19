using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjectCtrl
{
    [Header("Ship Ctrl")]
    [SerializeField] protected Inventory inventory;
    public Inventory GetInventory => inventory;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
    }
}
