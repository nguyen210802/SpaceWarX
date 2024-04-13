using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjectCtrl : NguyenMonoBehaviour
{
    [Header("Shootable Object Ctrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;

    [SerializeField] protected ShootableObjectSO shootableObject;
    public ShootableObjectSO ShootableObject => shootableObject;
    
    [SerializeField] protected ObjShooting objectShooting;
    public ObjShooting ObjectShooting => objectShooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadSO();
        this.LoadObjectShooting();
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
        if (this.objectShooting != null) return;
        this.objectShooting = GetComponentInChildren<ObjShooting>();
        Debug.Log(transform.name + ": LoadObjectShooting", gameObject);
    }

    protected abstract string GetObjectTypeString();
}
