using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : NguyenMonoBehaviour
{

    private void FixedUpdate()
    {
        this.Despawning();
    }

    protected virtual void Despawning()
    {
        if (!this.CanDespan())
            return;
        this.DespawnObject();
    }

    protected virtual void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected abstract bool CanDespan();
}
