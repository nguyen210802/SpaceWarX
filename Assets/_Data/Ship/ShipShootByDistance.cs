using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShootDistance : ObjShooting
{
    [Header("Shoot by distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance = Mathf.Infinity;
    [SerializeField] protected float shootDistance = 20f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected virtual void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.LogWarning(transform.name + ": LoadTarget", gameObject);
    }

    protected override void IsShooting()
    {
        if (this.target == null)
        {
            this.isShooting = false;
            return;
        }

        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isShooting = this.distance < this.shootDistance;
    }
}
