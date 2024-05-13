using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUpgrade : ShootableObjectUpgrade
{
    [Header("Enemy Upgrade")]
    [SerializeField] protected int level;
    [SerializeField] protected float critHpBonus = 0.1f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetLevel();
    }

    protected override void Start()
    {
        base.Start();
        this.UpgradeByLevel();
    }

    protected virtual void SetLevel()
    {
        this.level = GameCtrl.Instance.GetMapLevel;
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newCritHpBonus = this.level * this.critHpBonus;
        shootableObjectCtrl.GetShootableObjectDamageReceiver.SetCritHpBonus(newCritHpBonus);
    }
}
