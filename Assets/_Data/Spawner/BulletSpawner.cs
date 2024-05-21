using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public string bullet1 = "Bullet_1";
    public string bullet2 = "Bullet_2";
    public string bullet3 = "Bullet_3";
    public string rocket = "Rocket";
    public string explotion = "Explotion";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
            Debug.LogError("Only one BulletSpawner allow to exit!");
        BulletSpawner.instance = this;
    }
}
