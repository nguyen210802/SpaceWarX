using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected LaserDamageSender laserDamageSender;
    public LaserDamageSender GetLaserDamageSender => laserDamageSender;

    [SerializeField] protected LaserUpgrade laserUpgrade;
    public LaserUpgrade GetLaserUpgrade => laserUpgrade;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLaserDamageSender();
        this.LoadLaserUpgrade();
    }

    protected virtual void LoadLaserDamageSender()
    {
        if (this.laserDamageSender != null) return;
        this.laserDamageSender = transform.GetComponentInChildren<LaserDamageSender>();
        Debug.Log(transform.name + ": LoadLaserDamageSender", gameObject);
    }

    protected virtual void LoadLaserUpgrade()
    {
        if(this.laserUpgrade != null) return;
        this.laserUpgrade = transform.GetComponentInChildren<LaserUpgrade>();
        Debug.Log(transform.name + ": LoadLaserUpgrade", gameObject);
    }
}
