using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDamageSender : DamageSender
{
    [SerializeField] protected RocketCtrl rocketCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.rocketCtrl != null) return;
        this.rocketCtrl = transform.parent.GetComponent<RocketCtrl>();
        Debug.Log(transform.name + ": Load BulletCtrl", gameObject);
    }

    public override void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        base.SendByDamageReceiver(damageReceiver);
        //this.CreateFXImpact();
        //this.DestroyBullet();
    }

    //protected virtual void DestroyBullet()
    //{
    //    this.rocketCtrl.GetBulletDespawn.DespawnObject();
    //}

    //protected virtual void CreateFXImpact()
    //{
    //    string fxName = this.GetImpactFX();
    //    Vector3 hitPos = transform.parent.position;
    //    Quaternion hitRot = transform.parent.rotation;
    //    Transform FXImpact = FXSpawner.Instance.SpawnByName(fxName, hitPos, hitRot);
    //    FXImpact.gameObject.SetActive(true);
    //}

    //protected virtual string GetImpactFX()
    //{
    //    return FXSpawner.Instance.impact1;
    //}
}
