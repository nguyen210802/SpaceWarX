using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected LaserCtrl laserCtrl;
    [SerializeField] protected float valueCritDamageBonus = 0.2f;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLaserCtrl();
    }

    protected virtual void LoadLaserCtrl()
    {
        if (laserCtrl != null) return;
        laserCtrl = transform.parent.GetComponent<LaserCtrl>();
        Debug.Log(transform.name + ": LoadLaserCtrl", gameObject);
    }

    private void Update()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newDamage = ShipUpgrade.Instance.GetCurrentLevel * this.valueCritDamageBonus;
        laserCtrl.GetLaserDamageSender.SetCritDamageBonus(newDamage);
    }
}
