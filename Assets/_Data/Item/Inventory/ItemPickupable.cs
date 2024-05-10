using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]

public class ItemPickupable : ItemAbstact
{
    [Header("Item Pickupable")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int point;
    public int GetPoint => point;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.15f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    //public virtual void OnMouseDown()
    //{
    //    //Debug.Log(transform.parent.name);
    //    PlayerCtrl.Instance.GetPlayerPickup.ItemPickup(this);
    //}

    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        }
    }

    public virtual ItemCode GetItemCode()
    {
        return ItemPickupable.String2ItemCode(transform.parent.name);
    }

    public virtual void Picked()
    {
        this.itemCtrl.GetItemDespawn.DespawnObject();
    }
}
