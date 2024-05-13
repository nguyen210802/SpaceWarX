using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawnerRandom : SpawnerRandom
{
    private static MotherShipSpawnerRandom instance;
    public static MotherShipSpawnerRandom Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawnerRandom.instance != null)
            Debug.LogError("Only one MotherShipSpawnerRandom allow to exit!");
        MotherShipSpawnerRandom.instance = this;
    }

    public void SetRandomLimit(int limit)
    {
        this.spawnLimit = limit;
    }
}
