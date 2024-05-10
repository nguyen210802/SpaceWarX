using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : NguyenMonoBehaviour
{
    [SerializeField] protected float damage = 1;
    public float GetDamage => damage;

    [SerializeField] protected float critDamageBonus = 0f;
    public void SetCritDamageBonus(float value) { this.critDamageBonus = value; }

    public virtual void SendByTransform(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null)
            return;
        this.SendByDamageReceiver(damageReceiver);
    }

    public virtual void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        float valueDamage = this.damage * (1 + this.critDamageBonus);
        damageReceiver.Deduct(valueDamage);
        Debug.Log(transform.parent.name + ": " + valueDamage);
    }
}
