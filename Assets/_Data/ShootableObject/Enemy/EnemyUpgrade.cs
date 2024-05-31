using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyUpgrade : ShootableObjectUpgrade
{
    [Header("Enemy Upgrade")]
    [SerializeField] protected int level = 0;
    [SerializeField] protected float critHpBonus = 0.2f;

    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetLevel();
        Debug.Log("Helo");
    }

    //protected override void Start()
    //{
    //    base.Start();
    //    this.UpgradeByLevel();
    //}

    protected virtual void SetLevel()
    {
        this.level = GameCtrl.Instance.GetGameMapLevel.GetMapLevel;
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newCritHpBonus = this.level * this.critHpBonus;
        shootableObjectCtrl.GetShootableObjectDamageReceiver.SetCritHpBonus(newCritHpBonus);
    }
}
