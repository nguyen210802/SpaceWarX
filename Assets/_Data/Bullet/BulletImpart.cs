using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent (typeof(Rigidbody))]

public class BulletImpart : BulletAbstract
{
    [Header("Bullet Impart")]
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected new Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(0.22f, 0.15f, 1);
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == this.GetBulletCtrl.GetShooter.tag) return;

        this.bulletCtrl.GetBulletDamageSender.SendByTransform(other.transform);
    }
}
