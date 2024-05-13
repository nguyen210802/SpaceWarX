using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerRandom : SpawnerRandom
{
    private static BossSpawnerRandom instance;
    public static BossSpawnerRandom Instance => instance;

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
}
