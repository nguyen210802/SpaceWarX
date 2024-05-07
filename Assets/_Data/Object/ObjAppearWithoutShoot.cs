using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearWithoutShoot : NguyenMonoBehaviour, IObjAppeearObserver
{
    [Header("Without Shoot")]

    [SerializeField] protected EnemyCtrl enemyCtrl;
    public EnemyCtrl GetEnemyCtrl => enemyCtrl;

    [SerializeField] protected ObjAppearing objectAppearing;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.RegisterAppearEvent();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadObjectAppearing();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + "LoadEnemyCtrl", gameObject);
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
        this.enemyCtrl.GetObjectShooting.gameObject.SetActive(false);
        this.enemyCtrl.GetObjLookAtTarget.gameObject.SetActive(false);

    }

    public void OnAppearFinish()
    {
        this.enemyCtrl.GetObjectShooting.gameObject.SetActive(true);
        this.enemyCtrl.GetObjLookAtTarget.gameObject.SetActive(true);

        this.enemyCtrl.GetSpawner.Hold(transform.parent);
    }
}
