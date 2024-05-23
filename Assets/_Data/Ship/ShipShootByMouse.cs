using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipShootByMouse : ObjShooting
{
    protected override void Start()
    {
        base.Start();
        this.bulletName = BulletSpawner.Instance.shipBullet_1;
    }
    protected override void IsShooting()
    {
        if (Input.GetMouseButton(0))
            this.isShooting = true;
        else
            this.isShooting = false;
    }
}
