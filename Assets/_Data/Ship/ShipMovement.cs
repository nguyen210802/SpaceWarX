using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShipMovement : NguyenMonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float speed = 0.01f;
    [SerializeField] protected float distance = 1f;
    [SerializeField] protected float minDistance = 3f;

    protected virtual void FixedUpdate()
    {
        this.LookAtTarget();
        this.Moving();
    }
    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0, 0, rot_z);
    }

    protected virtual void Moving()
    {
        this.distance = Vector3.Distance(transform.position, this.targetPosition);
        if (this.distance < this.minDistance) return;
        Vector3 newPos = Vector3.Lerp(transform.parent.position, targetPosition, speed);
        transform.parent.position = newPos;
    }
}
