using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : ObjShooting
{
    [Header("Boss Shooting")]
    [SerializeField] protected int coutBullet = 5;

    protected override void IsShooting()
    {
        this.isShooting = true;
        //return this.isShooting;
    }

    protected override void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.parent.position;

        float angle = 360 / coutBullet;
        
        for(int i=0; i< coutBullet; i++)
        {
            Quaternion rotation = transform.parent.rotation * Quaternion.Euler(0, 0, angle * i);
            Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.bulletOne, spawnPos, rotation);
            if (newBullet == null)
                return;

            BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
            bulletCtrl.SetShotter(transform.parent);

            newBullet.gameObject.SetActive(true);
        }
        
    }
}
