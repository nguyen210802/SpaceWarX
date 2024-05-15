using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipShootByMouse : ObjShooting
{
    protected override void IsShooting()
    {
        //this.isShooting = InputManager.Instance.GetOnPiring == 1;
        //return isShooting;
        //return Input.GetAxis("Fire1") == 1;
        if (Input.GetMouseButton(0))
            this.isShooting = true;
        else
            this.isShooting = false;
    }
}
