using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected float valueCritDamageBonus = 0.1f;

    private void Update()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newDamage = ShipUpgrade.Instance.GetCurrentLevel * this.valueCritDamageBonus;
    }
}
