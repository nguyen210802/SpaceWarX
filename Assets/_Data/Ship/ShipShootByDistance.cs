using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootDistance : ObjShooting
{
    [Header("Shoot by distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 3f;

    public virtual void SetTarget(Transform target)
    {
        this.target = target;
    }

    protected override void IsShooting()
    {
        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isShooting = this.distance < this.shootDistance;
    }
}
