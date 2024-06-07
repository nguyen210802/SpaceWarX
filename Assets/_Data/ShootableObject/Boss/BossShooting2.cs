using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting2 : ObjShooting
{
    [SerializeField] protected int countBullet = 3;
    [SerializeField] protected float shootingRange = 60;

    protected override void Start()
    {
        base.Start();
        this.bulletName = BulletSpawner.Instance.bossBullet_1;
    }

    protected override void IsShooting()
    {
        this.isShooting = true;
    }

    protected override void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.parent.position;

        float angle = shootingRange / (countBullet - 1);

        for (int i = 0; i < countBullet; i++)
        {
            Quaternion rot = transform.parent.rotation * Quaternion.Euler(0, 0, (angle * i) - (shootingRange / 2));

            Transform newBullet = BulletSpawner.Instance.SpawnByName(bulletName, spawnPos, rot);
            if (newBullet == null)
                return;

            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShotter(transform.parent);

            newBullet.gameObject.SetActive(true);
        }

    }
}
