using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByInvisible : NguyenMonoBehaviour
{
    [SerializeField] protected Transform shooting;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShooting();
    }
    protected virtual void LoadShooting()
    {
        if (this.shooting != null) return;

        ShootableObjectCtrl shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        this.shooting = shootableObjectCtrl.GetObjectShooting.transform;
    }

    private void FixedUpdate()
    {
        this.SetShootingByInvisible();
    }

    protected virtual void SetShootingByInvisible()
    {
        shooting.gameObject.SetActive(!Invisible.Instance.GetInvisible);
    }
}
