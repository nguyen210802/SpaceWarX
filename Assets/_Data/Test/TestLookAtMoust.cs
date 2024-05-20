using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLookAtMoust : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;

    protected virtual void FixedUpdate()
    {
        this.targetPosition = InputManager.Instance.GetMouseWorldPos;
        this.targetPosition.z = 0;
        this.LookAtTarget();
    }

    protected virtual void LookAtTarget()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0, 0, rot_z);

        transform.parent.rotation = targetEuler;
    }
}
