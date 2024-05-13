using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawner : Spawner
{
    protected static BossSpawner instance;
    public static BossSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (BossSpawner.instance != null)
            Debug.LogError("Only one BossSpawner allow to exit!");
        BossSpawner.instance = this;
    }
}
