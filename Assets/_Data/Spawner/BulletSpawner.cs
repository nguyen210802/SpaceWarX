using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public string bulletOne = "Bullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
            Debug.LogError("Only one BulletSpawner allow to exit!");
        BulletSpawner.instance = this;
    }
}
