using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperSpawner : Spawner
{
    protected static SniperSpawner instance;
    public static SniperSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (SniperSpawner.instance != null)
            Debug.LogError("Only one SniperSpawner allow to exit!");
        SniperSpawner.instance = this;
    }
}
