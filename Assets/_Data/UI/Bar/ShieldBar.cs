using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBar : Bar
{
    protected override void SetValue()
    {
        GameObject shield = SkillShield.Instance.GetShield;
        ShieldDamageReceiver damageReceiver = shield.GetComponentInChildren<ShieldDamageReceiver>();
        this.currentValue = damageReceiver.GetHp;
        this.maxValue = damageReceiver.GetMaxHp;
    }
}
