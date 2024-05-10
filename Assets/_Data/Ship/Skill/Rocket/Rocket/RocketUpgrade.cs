using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected RocketCtrl rocketCtrl;
    [SerializeField] protected float valueCritDamageBonus = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (rocketCtrl != null) return;
        rocketCtrl = transform.parent.GetComponent<RocketCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    private void Update()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newDamageBonus = ShipUpgrade.Instance.GetCurrentLevel * this.valueCritDamageBonus;
        rocketCtrl.GetRocketDamageSender.SetCritDamageBonus(newDamageBonus);
    }
}
