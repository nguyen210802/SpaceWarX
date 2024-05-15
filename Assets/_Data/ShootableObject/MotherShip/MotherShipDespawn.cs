using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        MotherShipSpawner.Instance.Despawn(transform.parent);
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.disLimit = 300;
    }
}
