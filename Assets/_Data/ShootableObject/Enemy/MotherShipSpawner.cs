using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipSpawner : Spawner
{
    protected static MotherShipSpawner instance;
    public static MotherShipSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (MotherShipSpawner.instance != null)
            Debug.LogError("Only one MotherShipSpawner allow to exit!");
        MotherShipSpawner.instance = this;
    }
}
