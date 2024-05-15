using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (SphereCollider))]

public class DamageReceiver : NguyenMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;

    [SerializeField] protected float hp = 1;
    public float GetHp => hp;
    [SerializeField] protected float baseHp = 2;
    public float GetBaseHp => baseHp;

    [SerializeField] protected float critHpBonus = 0f;
    public void SetCritHpBonus(float critHp) 
    { 
        this.critHpBonus = critHp;
        this.UpgradeByLevel();
    }

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
        this.hp = this.baseHp;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        this.hp += add;
        if(this.hp > this.baseHp)   this.hp = this.baseHp;
    }

    public virtual void Deduct(float deduct)
    {
        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void UpgradeByLevel()
    {
        if (this.critHpBonus == 0) return;
        float newHp = this.baseHp * (1 + this.critHpBonus);
        this.hp = newHp;
    }

    protected virtual void OnDead() { }
}
