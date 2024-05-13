using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    [Header("Enemy Ctrl")]
    //[SerializeField] protected ShootableObjectDamageReceiver objDamageReveiver;
    //public ShootableObjectDamageReceiver GetShootableObjectDamageReceiver => objDamageReveiver;

    //[SerializeField] protected EnemyUpgrade enemyUpgrade;
    //public EnemyUpgrade GetEnemyUpgrade => enemyUpgrade;

    [SerializeField] protected Spawner spawner;
    public Spawner GetSpawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        //this.LoadShootableObjectDamageReceiver();
        //this.LoadEnemyUpgrade();
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }

    //protected virtual void LoadShootableObjectDamageReceiver()
    //{
    //    if (this.objDamageReveiver != null) return;
    //    this.objDamageReveiver = GetComponentInChildren<ShootableObjectDamageReceiver>();
    //    Debug.Log(transform.name + ": LoadShootableObjectDamageReceiver", gameObject);
    //}

    //protected virtual void LoadEnemyUpgrade()
    //{
    //    if (this.enemyUpgrade != null) return;
    //    this.enemyUpgrade = GetComponentInChildren<EnemyUpgrade>();
    //    Debug.Log(transform.name + ": LoadEnemyUpgrade", gameObject);
    //}

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}
