using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : DamageReceiver
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
        this.shipCtrl.GetDespawn.DespawnObject();
        this.OnDeadFX();
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXSmoke();
        Transform fxOnDead = FXSpawner.Instance.SpawnByName(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXSmoke()
    {
        return FXSpawner.Instance.smoke1;
    }

    public override void Reborn()
    {
        this.maxHp = this.shipCtrl.GetShootableObject.maxHp;
        base.Reborn();
    }
}
