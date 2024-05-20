using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkDamageReceiver : DamageReceiver
{
    [Header("Junk")]
    [SerializeField] protected JunkCtrl junkCtrl;
    [SerializeField] protected int point;

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
        if (this.junkCtrl != null) return;
        this.junkCtrl = transform.parent.GetComponent<JunkCtrl>();
        Debug.Log(transform.name + ": Load JunkCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.junkCtrl.GetJunkDespawn.DespawnObject();
        TextPoint.Instance.AddPoint(point);
        this.OnDeadDrop();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.junkCtrl.GetShootableObject.dropList, dropPos, dropRot);
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
        this.baseHp = this.junkCtrl.GetShootableObject.baseHp;
        base.Reborn();
    }
}
