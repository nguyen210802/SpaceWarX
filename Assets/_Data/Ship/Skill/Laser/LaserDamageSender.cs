using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserDamageSender : DamageSender
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.SetDamage();
    }

    protected virtual void SetDamage()
    {
        this.damage = 0.2f;
        this.critDamageBonus = 0.1f;
    }
}
