using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamageSender : NguyenMonoBehaviour
{
    [SerializeField] protected float damage = 1;
    public float GetDamage => damage;
    [SerializeField] protected float timer = 0f;
    [SerializeField] protected float timeCD = 1f;

    private void FixedUpdate()
    {
        this.timer -= Time.fixedDeltaTime;
    }

    public virtual void SendByTransform(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponent<DamageReceiver>();
        if (damageReceiver == null)
            return;
        if (this.timer > 0f) return;
        this.SendByDamageReceiver(damageReceiver);
    }

    public virtual void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
        this.timer = timeCD;
    }
}
