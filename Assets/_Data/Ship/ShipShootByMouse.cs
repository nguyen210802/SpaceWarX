using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootByMouse : ObjectShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnPiring == 1;
        return isShooting;
    }
}
