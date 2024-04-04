using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelByDistance : Level
{
    [Header("By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel = 10f;

    protected virtual void FixedUpdate()
    {
        this.Leving();
    }

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected virtual void Leving()
    {
        if (this.target == null) return;
        this.distance = Vector3.Distance(transform.position, this.target.position);
        int newLevel = this.GetLevelByDis();
        this.LevelSet(newLevel);
    }

    protected virtual int GetLevelByDis()
    {
        return Mathf.FloorToInt(this.distance / this.distancePerLevel);
    }
}
