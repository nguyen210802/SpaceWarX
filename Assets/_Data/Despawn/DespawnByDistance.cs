using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 20f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Camera mainCam;

    protected override void LoadComponents()
    {
        this.LoadCamera();
    }


    protected virtual void LoadCamera()
    {
        if (this.mainCam != null) return;
        this.mainCam = Transform.FindObjectOfType<Camera>();
        Debug.Log(transform.parent.name + ": LoadCamera");
    }

    protected override bool CanDespan()
    {
        this.distance = Vector2.Distance(transform.parent.position, mainCam.transform.position);
        if (this.distance > this.disLimit)
            return true;
        return false;
    }
}
