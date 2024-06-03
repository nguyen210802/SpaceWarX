using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ShipDamageReceiver : ShootableObjectDamageReceiver
{
    [Header("ShipDamageReceiver")]
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected new Rigidbody rigidbody;
    
    [SerializeField] protected bool shield = false;
    public void SetShield(bool shield) { this.shield = shield; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        rigidbody.useGravity = false;
        rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + ": LoadCollider", gameObject);
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

    public override void Deduct(float deduct)
    {
        if (shield) return;

        base.Deduct(deduct);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.OnDeadFX();
        GameCtrl.Instance.GetGameWave.PlayerDespawn();
        this.shipCtrl.GetDespawn.DespawnObject();
    }

    protected override string GetOnDeadFXSmoke()
    {
        return FXSpawner.Instance.explotion;
    }
}
