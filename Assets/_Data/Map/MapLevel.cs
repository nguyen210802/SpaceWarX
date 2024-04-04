using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.MapSetTarget();
    }

    protected virtual void MapSetTarget()
    {
        if (this.target != null) return;
        ShipCtrl currentShip = PlayerCtrl.Instance.CurrentShip;
        this.SetTarget(currentShip.transform);
    }
}
