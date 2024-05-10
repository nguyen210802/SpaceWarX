using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected ShieldCtrl shieldCtrl;
    [SerializeField] protected float critHpBonus = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShieldCtrl();
    }

    protected virtual void LoadShieldCtrl()
    {
        if (this.shieldCtrl != null) return;
        this.shieldCtrl = transform.parent.GetComponent<ShieldCtrl>();
        Debug.Log(transform.name + ": LoadShieldCtrl", gameObject);
    }

    private void FixedUpdate()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newCritHpBonus = ShipUpgrade.Instance.GetCurrentLevel * this.critHpBonus;
        shieldCtrl.GetDamageReceiver.SetCritHpBonus(newCritHpBonus);
    }
}
