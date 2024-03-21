using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float desLimit = 5f;
    [SerializeField] protected float desTime = 0f;
    protected override bool CanDespan()
    {
        this.desTime += Time.fixedDeltaTime;
        //if (this.desTime > this.desLimit)
        //    return true;
        //return false;
        return desTime > desLimit;
    }
}
