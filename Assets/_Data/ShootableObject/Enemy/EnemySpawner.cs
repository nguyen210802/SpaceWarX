using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (EnemySpawner.instance != null)
            Debug.LogError("Only one JunkSpawner allow to exit!");
        EnemySpawner.instance = this;
    }
}
