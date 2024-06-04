using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerRandom : SpawnerRandom
{
    private static EnemySpawnerRandom instance;
    public static EnemySpawnerRandom Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawnerRandom.instance != null)
            Debug.LogError("Only one EnemySpawnerRandom allow to exit!");
        EnemySpawnerRandom.instance = this;
    }

    public void SetRandomLimit(int limit)
    {
        this.spawnLimit = limit;
    }
}
