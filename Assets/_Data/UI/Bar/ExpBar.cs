using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpBar : Bar
{
    protected override void SetValue()
    {
        this.currentValue = ShipUpgrade.Instance.GetUpgradePoint;
        this.maxValue = ShipUpgrade.Instance.GetNextUpgradePoint;
    }
}
