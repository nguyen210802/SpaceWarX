using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCtrl : ShootableObjectCtrl
{
    [Header("Ability Object")]
    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints GetSpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawnPoints()
    {
        if (spawnPoints != null) return;
        this.spawnPoints = GetComponentInChildren<SpawnPoints>();
        Debug.Log(transform.name + ": LoadSpawnPoints", gameObject);
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
