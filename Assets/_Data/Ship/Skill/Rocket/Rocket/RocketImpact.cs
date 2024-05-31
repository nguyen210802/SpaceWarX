using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]


public class RocketImpact : NguyenMonoBehaviour
{
    [SerializeField] protected RocketCtrl rocketCtrl;
    [SerializeField] protected BoxCollider boxCollider;
    [SerializeField] protected new Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRocketCtrl();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadRocketCtrl()
    {
        if (this.rocketCtrl != null) return;
        this.rocketCtrl = transform.parent.GetComponent<RocketCtrl>();
        Debug.Log(transform.name + ": LoadRocketCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.boxCollider != null) return;
        this.boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
        boxCollider.size = new Vector3(0.33f, 0.22f, 1);
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
        if (other.transform.parent.tag == this.rocketCtrl.GetShooter.tag) return;
        if (other.transform.parent.tag == this.rocketCtrl.tag) return;

        this.rocketCtrl.GetRocketDamageSender.SendByTransform(other.transform);
        this.rocketCtrl.GetRocketDespawn.DespawnObject();
    }
}
