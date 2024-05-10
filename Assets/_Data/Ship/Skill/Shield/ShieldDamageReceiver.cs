using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldDamageReceiver : DamageReceiver
{
    [Header("Shield")]
    [SerializeField] protected ShieldCtrl shieldCtrl;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.maxHp = 5;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (this.shieldCtrl != null) return;
        this.shieldCtrl = transform.parent.GetComponent<ShieldCtrl>();
        Debug.Log(transform.name + ": LoadShieldCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        shieldCtrl.GetSkillShield.TimeDespawn();
        shieldCtrl.GetDespawn.DespawnObject();
    }
}
