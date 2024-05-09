using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerRandom : NguyenMonoBehaviour
{
    [Header("Spawn Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float spawnDelay = 1f;
    [SerializeField] protected float spawnTime = 0f;
    [SerializeField] protected int spawnLimit = 9;

    public void SetSpawnDelay(float value) { this.spawnDelay = value; }
    public void SetSpawnLimit(int value) { this.spawnLimit = value; }

    public void SetSpawn(float spawnDelay, int spawnLimit)
    {
        this.spawnDelay = spawnDelay;
        this.spawnLimit = spawnLimit;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if (this.RandomReachLimit()) return;

        this.spawnTime += Time.fixedDeltaTime;
        if (this.spawnTime < this.spawnDelay) return;
        this.spawnTime = 0f;

        Transform randomPoint = this.spawnerCtrl.GetSpawnPoints.GetRanDom();
        Vector3 pos = randomPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.GetSpawner.RandomPrefab();
        Transform obj = this.spawnerCtrl.GetSpawner.SpawnByTransform(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currentSpawn = this.spawnerCtrl.GetSpawner.GetSpawnedCount;
        return currentSpawn >= this.spawnLimit;
    }
}
