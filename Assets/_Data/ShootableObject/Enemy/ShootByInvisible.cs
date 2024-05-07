using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByInvisible : NguyenMonoBehaviour
{
    [SerializeField] protected Transform shooting;

    //[SerializeField] protected bool checkShipInvisible = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShooting();
    }
    protected virtual void LoadShooting()
    {
        if (this.shooting != null) return;

        EnemyCtrl enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        this.shooting = enemyCtrl.GetObjectShooting.transform;
    }

    private void FixedUpdate()
    {
        this.SetShootingByInvisible();
    }

    //protected virtual void ChangeActiveShooting()
    //{
    //    if (this.checkShipInvisible == Invisible.Instance.GetInvisible) return;

    //    this.SetShootingByInvisible();
    //}

    protected virtual void SetShootingByInvisible()
    {
        //this.checkShipInvisible = Invisible.Instance.GetInvisible;
        shooting.gameObject.SetActive(!Invisible.Instance.GetInvisible);
    }
}
