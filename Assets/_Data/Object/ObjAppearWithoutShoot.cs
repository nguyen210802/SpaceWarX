using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : ShootableObjectAbstract, IObjAppeearObserver
{
    [Header("Without Shoot")]
    [SerializeField] protected ObjAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjectAppearing();
    }

    protected virtual void LoadObjectAppearing()
    {
        if (this.objectAppearing != null) return;
        this.objectAppearing = GetComponent<ObjAppearing>();
        Debug.Log(transform.name + ": LoadObjectAppearing", gameObject);
    }

    protected virtual void RegisterAppearEvent()
    {
        this.objectAppearing.AddObserver(this);
    }

    public void OnAppearStart()
    {
        this.shootableObjectCtrl.GetObjectShooting.gameObject.SetActive(false);
        this.shootableObjectCtrl.GetObjLookAtTarget.gameObject.SetActive(false);

    }

    public void OnAppearFinish()
    {
        this.shootableObjectCtrl.GetObjectShooting.gameObject.SetActive(true);
        this.shootableObjectCtrl.GetObjLookAtTarget.gameObject.SetActive(true);

        this.shootableObjectCtrl.GetSpawner.Hold(transform.parent);
    }
}
