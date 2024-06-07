using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDamageSender : DamageSender
{
    [SerializeField] protected RocketCtrl rocketCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRocketCtrl();
    }

    protected virtual void LoadRocketCtrl()
    {
        if (this.rocketCtrl != null) return;
        this.rocketCtrl = transform.parent.GetComponent<RocketCtrl>();
        Debug.Log(transform.name + ": LoadRocketCtrl", gameObject);
    }

    public override void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        base.SendByDamageReceiver(damageReceiver);
        //this.CreateFXImpact();
        //this.DestroyBullet();
    }
}
