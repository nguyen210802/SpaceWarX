using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    [SerializeField] protected float valueCritDamageBonus = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }

    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
        Debug.Log(transform.name + ": LoadBulletCtrl", gameObject);
    }

    private void Update()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newDamage = ShipUpgrade.Instance.GetCurrentLevel * this.valueCritDamageBonus;
        bulletCtrl.GetBulletDamageSender.SetCritDamageBonus(newDamage);
    }
}
