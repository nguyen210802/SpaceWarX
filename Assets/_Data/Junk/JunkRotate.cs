using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRotate : JunkAbstact
{
    [SerializeField] protected float speed = 9f;

    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }

    protected virtual void Rotating()
    {
        Vector3 eulers = Vector3.forward;
        this.JunkCtrl.Model.Rotate(eulers * this.speed * Time.deltaTime);
    }
}
