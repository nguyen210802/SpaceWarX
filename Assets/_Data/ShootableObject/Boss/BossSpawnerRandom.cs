using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerRandom : SpawnerRandom
{
    private static BossSpawnerRandom instance;
    public static BossSpawnerRandom Instance => instance;

    [SerializeField] protected int totalSpawnLimit = 0;
    public void SetTotalSpawnLimit(int value) { this.totalSpawnLimit = value; }

    protected override void Awake()
    {
        base.Awake();
        if (BossSpawnerRandom.instance != null)
            Debug.LogError("Only one BossSpawnerRandom allow to exit!");
        BossSpawnerRandom.instance = this;
    }

    public void SetRandomLimit(int limit)
    {
        this.spawnLimit = limit;
    }

    protected override bool RandomReachLimit()
    {
        int currentSpawn = this.spawnerCtrl.GetSpawner.GetSpawnedCount;
        int currentTotalSpawn = this.spawnerCtrl.GetSpawner.GetTotalSpawnedCount;

        if (currentSpawn >= this.spawnLimit)
            return true;
        if (this.totalSpawnLimit != 0 && currentTotalSpawn >= this.totalSpawnLimit)
            return true;
        return false;
    }
}
