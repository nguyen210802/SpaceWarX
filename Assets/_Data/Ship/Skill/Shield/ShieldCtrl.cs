using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected SkillShield skillShield;
    public SkillShield GetSkillShield => skillShield;

    [SerializeField] protected Despawn despawn;
    public Despawn GetDespawn => despawn;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver GetDamageReceiver => damageReceiver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillShield();
        this.LoadDespawn();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadSkillShield()
    {
        if (this.skillShield != null) return;
        this.skillShield = transform.parent.GetComponent<SkillShield>();
        Debug.Log(transform.name + ": LoadSkillShield", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadShieldDespawn", gameObject);
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }
}
