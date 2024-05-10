using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ShipLooter : NguyenMonoBehaviour
{
    [Header("Item Looter")]
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected new Rigidbody rigidbody;
    [SerializeField] protected ShipUpgrade shipUpgrade;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
        this.LoadShipUpgrade();
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.4f;
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
    protected virtual void LoadShipUpgrade()
    {
        if (this.shipUpgrade != null) return;
        this.shipUpgrade = transform.GetComponent<ShipUpgrade>();
        Debug.Log(transform.name + ": LoadShipUpgrade", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null)
            return;
        int point = itemPickupable.GetPoint;
        shipUpgrade.AddUpgradePoint(point);
        shipUpgrade.checkUpgrade();
        itemPickupable.Picked();
    }
}
