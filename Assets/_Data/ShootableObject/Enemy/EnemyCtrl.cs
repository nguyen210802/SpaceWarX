using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ShootableObjectCtrl
{
    [SerializeField] protected Spawner spawner;
    public Spawner GetSpawner => spawner;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = transform.parent?.parent?.GetComponent<Spawner>();
        Debug.Log(transform.name + ": LoadSpawner", gameObject);
    }
}
