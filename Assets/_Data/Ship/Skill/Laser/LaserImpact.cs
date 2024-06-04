using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]

public class LaserImpact : NguyenMonoBehaviour
{
    [Header("Laser Impart")]
    [SerializeField] protected LaserCtrl laserCtrl;

    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected new Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLaserCtrl();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadLaserCtrl()
    {
        if (this.laserCtrl != null) return;
        this.laserCtrl = transform.parent.GetComponent<LaserCtrl>();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
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

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.transform.parent.tag == this.laserCtrl.GetShooter.tag) return;
        this.laserCtrl.GetLaserDamageSender.SendByTransform(other.transform);
    }
}
