using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : ShootableObjectDamageReceiver
{
    [Header("ShipDamageReceiver")]
    [SerializeField] protected ShipCtrl shipCtrl;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.OnDeadFX();
        GameCtrl.Instance.PlayerDespawn();
        this.shipCtrl.GetDespawn.DespawnObject();
    }

    protected override string GetOnDeadFXSmoke()
    {
        return FXSpawner.Instance.explotion;
    }

    public override void Reborn()
    {
        this.baseHp = this.shipCtrl.GetShootableObject.baseHp;
        base.Reborn();
    }
}