using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : ObjMoveFoward
{
    private void Update()
    {
        this.MoveLimit();
    }

    protected virtual void MoveLimit()
    {
        float x = MapCtrl.Instance.GetLimitX;
        float y = MapCtrl.Instance.GetLimitY;

        Vector3 currentPosition = transform.parent.position;
        currentPosition.x = Mathf.Clamp(currentPosition.x, -x, x);
        currentPosition.y = Mathf.Clamp(currentPosition.y, -y, y);

        transform.parent.position = currentPosition;
    }
}
