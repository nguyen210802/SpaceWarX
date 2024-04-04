using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }

    protected virtual void LoadJunkCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": Load JunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.shootableObjectCtrl.Despawn.DespawnObject();
        //Drop here
        this.OnDeadDrop();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.ShootableObject.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX()
    {
        string fxName = this.GetOnDeadFXSmoke();
        Transform fxOnDead = FXSpawner.Instance.Spawn(fxName, transform.position, transform.rotation);
        fxOnDead.gameObject.SetActive(true);
    }

    protected virtual string GetOnDeadFXSmoke()
    {
        return FXSpawner.Instance.smoke1;
    }

    public override void Reborn()
    {
        this.maxHp = this.shootableObjectCtrl.ShootableObject.maxHp;
        base.Reborn();
    }
}
