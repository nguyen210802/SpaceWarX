using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectDamageReceiver : DamageReceiver
{
    [Header("Shootable Object")]
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;
    [SerializeField] protected int point;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.Reborn();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjectCtrl();
    }

    protected virtual void LoadShootableObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootableObjectCtrl", gameObject);
    }

    protected override void OnDead()
    {
        base.OnDead();
        this.shootableObjectCtrl.GetDespawn.DespawnObject();
        TextPoint.Instance.AddPoint(point);
        this.OnDeadFX();
        if(transform.parent.tag.Equals("Enemy"))
            AudioManager.Instance.PlaySfx(AudioManager.Instance.enemyDespawnAudioClip);
        //Drop here
        this.OnDeadDrop();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.shootableObjectCtrl.GetShootableObject.dropList, dropPos, dropRot);
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
        this.baseHp = this.shootableObjectCtrl.GetShootableObject.baseHp;
        sphereCollider.radius = shootableObjectCtrl.GetShootableObject.radius;
        this.point = shootableObjectCtrl.GetShootableObject.point;
        base.Reborn();
    }
}
