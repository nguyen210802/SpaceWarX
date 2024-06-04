using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShooting : NguyenMonoBehaviour
{
    public virtual void Shoot(Vector3 pos, Quaternion rot)
    {
        Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.SniperBullet_1, pos, rot);
        if (newBullet == null)
            return;

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);

        newBullet.gameObject.SetActive(true);
    }
}
