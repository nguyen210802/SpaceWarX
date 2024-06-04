using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSpawnerRandom : SpawnerRandom
{
    private static SniperSpawnerRandom instance;
    public static SniperSpawnerRandom Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (SniperSpawnerRandom.instance != null)
            Debug.LogError("Only one SniperSpawnerRandom allow to exit!");
        SniperSpawnerRandom.instance = this;
    }

    public void SetRandomLimit(int limit)
    {
        this.spawnLimit = limit;
    }
}
