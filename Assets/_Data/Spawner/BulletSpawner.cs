using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    private static BulletSpawner instance;
    public static BulletSpawner Instance => instance;

    public string shipBullet_1 = "ShipBullet_1";
    public string shipBullet_2 = "ShipBullet_2";
    public string shipBullet_3 = "ShipBullet_3";
    public string rocket = "Rocket";
    public string explotion = "Explotion";

    public string enemyBullet_1 = "EnemyBullet_1";
    public string bossBullet_1 = "BossBullet_1";

    protected override void Awake()
    {
        base.Awake();
        if (BulletSpawner.instance != null)
            Debug.LogError("Only one BulletSpawner allow to exit!");
        BulletSpawner.instance = this;
    }
}
