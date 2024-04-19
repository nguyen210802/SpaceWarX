using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawner : Spawner
{
    private static JunkSpawner instance;
    public static JunkSpawner Instance => instance;

    public static string meteoriteOne = "Meteorite_1";

    protected override void Awake()
    {
        base.Awake();
        if (JunkSpawner.instance != null)
            Debug.LogError("Only one JunkSpawner allow to exit!");
        JunkSpawner.instance = this;
    }
}
