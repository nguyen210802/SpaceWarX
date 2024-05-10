using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionDespawn : DespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delay = 0.6f;
    }

    public override void DespawnObject()
    {
        BulletSpawner.Instance.Despawn(transform.parent);
    }
}
