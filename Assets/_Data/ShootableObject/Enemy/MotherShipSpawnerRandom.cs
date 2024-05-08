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
        MotherShipSpawnerRandom.instance = this;
    }

    public void SetRandomLimit(int limit)
    {
        this.spawnLimit = limit;
    }
}
