using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected Spawner spawner;
    public Spawner GetSpawner => spawner;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints GetSpawnPoints=> spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadSpawner()
    {
        if (this.spawner != null) return;
        this.spawner = GetComponent<Spawner>();
        Debug.Log(transform.name + ": Load Spawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if(this.spawnPoints != null) return;
        this.spawnPoints = GameObject.Find("SceneSpawnPoints").GetComponent<SpawnPoints>();
        Debug.Log(transform.name + ": Load SpawnPoints", gameObject);
    }
}
