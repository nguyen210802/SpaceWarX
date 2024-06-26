using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected ExplotionCtrl expCtrl;
    [SerializeField] protected float valueCritDamageBonus = 0.1f;

    // protected override void Awake()
    // {
    //     if (expCtrl.GetShooter.CompareTag("Player"))
    //         this.UpgradeByLevel();
    // }

    protected override void OnEnable()
    {
        base.OnEnable();
        if (expCtrl.GetShooter.CompareTag("Player"))
            this.UpgradeByLevel();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadExplotionCtrl();
    }

    protected virtual void LoadExplotionCtrl()
    {
        if (this.expCtrl != null) return;
        this.expCtrl = transform.parent.GetComponent<ExplotionCtrl>();
        Debug.Log(transform.name + ": LoadExplotionCtrl", gameObject);
    }

    public virtual void UpgradeByLevel()
    {
        float newDamage = ShipUpgrade.Instance.GetCurrentLevel * this.valueCritDamageBonus;
        expCtrl.GetExpDamageSender.SetCritDamageBonus(newDamage);
    }
}
