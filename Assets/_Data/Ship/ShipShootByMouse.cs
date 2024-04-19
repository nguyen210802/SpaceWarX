using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.GetOnPiring == 1;
        return isShooting;
    }
}
