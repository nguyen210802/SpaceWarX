using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipFollowMouse : ObjMovement
{
    protected override void FixedUpdate()
    {
        this.GetMousePosition();
        base.FixedUpdate();
    }

    protected virtual void GetMousePosition()
    {
        this.targetPosition = InputManager.Instance.GetMouseWorldPos;
        this.targetPosition.z = 0;
    }
}
