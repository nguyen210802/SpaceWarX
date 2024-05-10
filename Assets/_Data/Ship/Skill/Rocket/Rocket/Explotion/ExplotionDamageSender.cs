using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionDamageSender : DamageSender
{
    [SerializeField] protected ExplotionCtrl expCtrl;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.damage = 10;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExplotionCtrl();
    }

    protected virtual void LoadExplotionCtrl()
    {
        if (this.expCtrl != null) return;
        this.expCtrl = transform.parent.GetComponent<ExplotionCtrl>();
        Debug.Log(transform.name + ": LoadExplotionCtrl", gameObject);
    }

    public override void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        base.SendByDamageReceiver(damageReceiver);
    }
}
