using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : NguyenMonoBehaviour
{
    [Header("Shootable Object Ctrl")]
    [SerializeField] protected Transform model;
    public Transform GetModel => model;

    [SerializeField] protected Despawn despawn;
    public Despawn GetDespawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO GetShootableObject => shootableObject;
    
    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting GetObjectShooting => objShooting;
    
    [SerializeField] protected ObjLookAtTarget objLookAtTarget;
    public ObjLookAtTarget GetObjLookAtTarget => objLookAtTarget;

    [SerializeField] protected ShootableObjectDamageReceiver objDamageReveiver;
    public ShootableObjectDamageReceiver GetShootableObjectDamageReceiver => objDamageReveiver;

    [SerializeField] protected MonsterDamageSender monsterDamageSender;
    public MonsterDamageSender GetMonsterDamageSender => monsterDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjectShooting();
        this.LoadObjLookAtTarget();
        this.LoadShootableObjectDamageReceiver();
        this.LoadMonsterDamageSender();
    }

    protected virtual void LoadModel()
    {
        if (this.model != null) return;
        this.model = transform.Find("Model");
        Debug.Log(transform.name + ": LoadModel", gameObject);
    }

    protected virtual void LoadDespawn()
    {
        if (this.despawn != null) return;
        this.despawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": Load JunkDespawn", gameObject);
    }

    protected virtual void LoadSO()
    {
        if (this.shootableObject != null) return;
        string resPath = "ShootableObject/"+this.GetObjectTypeString()+"/"+transform.name;
        this.shootableObject = Resources.Load<ShootableObjectSO>(resPath);
        Debug.Log(transform.name + ": LoadSO" + resPath, gameObject);
    }

    protected virtual void LoadObjectShooting()
    {
        if (this.objShooting != null) return;
        this.objShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjectShooting", gameObject);
    }

    protected virtual void LoadObjLookAtTarget()
    {
        if (this.objLookAtTarget != null) return;
        this.objLookAtTarget = GetComponentInChildren<ObjLookAtTarget>();
        Debug.Log(transform.name + ": LoadObjLookAtTarget", gameObject);
    }

    protected virtual void LoadShootableObjectDamageReceiver()
    {
        if (this.objDamageReveiver != null) return;
        this.objDamageReveiver = GetComponentInChildren<ShootableObjectDamageReceiver>();
        Debug.Log(transform.name + ": LoadShootableObjectDamageReceiver", gameObject);
    }

    protected virtual void LoadMonsterDamageSender()
    {
        if (this.monsterDamageSender != null) return;
        this.monsterDamageSender = GetComponentInChildren<MonsterDamageSender>();
        Debug.Log(transform.name + ": LoadMonsterDamageSender", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
