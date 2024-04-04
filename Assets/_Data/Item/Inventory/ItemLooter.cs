using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ItemLooter : InventoryAbstract
{
    [Header("Item Looter")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected new Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.5f;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }
    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null)
            return;

        ItemInventory itemInventory = itemPickupable.ItemCtrl.ItemInventory;
        if (this.inventory.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
