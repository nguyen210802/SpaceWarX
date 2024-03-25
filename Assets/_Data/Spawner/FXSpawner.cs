using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    protected static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public string smoke1 = "Smoke_1";
    public string Impact1 = "Impact_1";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null)
            Debug.LogError("Only 1 FXSpawner allow to exit!");
        FXSpawner.instance = this;
    }
}
