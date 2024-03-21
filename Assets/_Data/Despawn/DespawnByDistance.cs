using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0;
    [SerializeField] protected Camera mainCam;

    private void FixedUpdate()
    {
        this.Despawning();
    }

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

    protected override void Despawning()
    {
        if (!this.CanDespan())
            return;
        this.DespawnObject();
    }

    protected override void DespawnObject()
    {
        Destroy(transform.parent.gameObject);
    }

    protected override bool CanDespan()
    {
        this.distance = Vector3.Distance(transform.parent.position, mainCam.transform.position);
        if (this.distance > this.disLimit)
            return true;
        return false;
    }
}
