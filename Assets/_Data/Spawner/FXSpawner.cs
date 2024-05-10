using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FXSpawner : Spawner
{
    private static FXSpawner instance;
    public static FXSpawner Instance => instance;

    public string smoke1 = "Smoke_1";
    public string impact1 = "Impact_1";
    public string explotion = "Explotion";

    protected override void Awake()
    {
        base.Awake();
        if (FXSpawner.instance != null)
            Debug.LogError("Only 1 FXSpawner allow to exit!");
        FXSpawner.instance = this;
    }
}
