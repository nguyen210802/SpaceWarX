using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (this.bulletCtrl != null) return;
        this.bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": Load BulletCtrl", gameObject);
    }

    public override void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        base.SendByDamageReceiver(damageReceiver);
        this.CreateFXImpact();
        this.DestroyBullet();
    }

    protected virtual void DestroyBullet()
    {
        this.bulletCtrl.GetBulletDespawn.DespawnObject();
    }

    protected virtual void CreateFXImpact()
    {
        string fxName = this.GetImpactFX();
        Vector3 hitPos = transform.parent.position;
        Quaternion hitRot = transform.parent.rotation;
        Transform FXImpact = FXSpawner.Instance.SpawnByName(fxName, hitPos, hitRot);
        FXImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.Instance.impact1;
    }
}
