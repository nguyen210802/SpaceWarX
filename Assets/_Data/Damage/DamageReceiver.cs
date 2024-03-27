using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (SphereCollider))]

public abstract class DamageReceiver : NguyenMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp  = 1;
    [SerializeField] protected int maxHp = 2;
    [SerializeField] protected bool isDead = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

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
        Debug.Log(transform.name + ": LoadCollider", gameObject);
    }

    public virtual void Reborn()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(int add)
    {
        this.hp += add;
        if(this.hp > this.maxHp)   this.hp = this.maxHp;
    }

    public virtual void Deduct(int deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected abstract void OnDead();
}