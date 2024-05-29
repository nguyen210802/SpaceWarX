using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]

public class ExprotionImpact : NguyenMonoBehaviour
{
    [SerializeField] protected ExplotionCtrl explotionCtrl;
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected new Rigidbody rigidbody;

    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timerExit = 0.2f;
    [SerializeField] protected bool canDamage = true;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {
        this.timer = 0f;
        this.canDamage = true;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExplotionCtrl();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadExplotionCtrl()
    {
        if (this.explotionCtrl != null) return;
        this.explotionCtrl = transform.parent.GetComponent<ExplotionCtrl>();
        Debug.Log(transform.name + ": LoadExplotionCtrl", gameObject);
    }

    protected virtual void LoadCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 2.5f;
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

    private void FixedUpdate()
    {
        if (!this.canDamage) return;

        timer += Time.fixedDeltaTime;
        if (this.timer >= this.timerExit)
            this.canDamage = false;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.tag == this.explotionCtrl.GetShooter.tag) return;
        if(!this.canDamage) return;

        this.explotionCtrl.GetExpDamageSender.SendByTransform(other.transform);
    }
}
