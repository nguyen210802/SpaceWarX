using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootableObjectUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected ShootableObjectCtrl shootableObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootAbleObjectCtrl();
    }

    protected virtual void LoadShootAbleObjectCtrl()
    {
        if (this.shootableObjectCtrl != null) return;
        this.shootableObjectCtrl = transform.parent.GetComponent<ShootableObjectCtrl>();
        Debug.Log(transform.name + ": LoadShootAbleObjectCtrl", gameObject);
    }
}
