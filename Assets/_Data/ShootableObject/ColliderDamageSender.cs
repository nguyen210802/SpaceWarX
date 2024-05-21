using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColliderDamageSender : MonoBehaviour
{
    [SerializeField] protected float damage = 1f;
    [SerializeField] protected float time = 0f;
    [SerializeField] protected float timeDelay = 2f;


    private void FixedUpdate()
    {
        this.time -= Time.fixedDeltaTime;
        if (this.time <= 0) this.time = 0;
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.transform.parent.tag);
        Debug.Log(other.transform.parent.name);
        Debug.Log(other.transform.name);
        
        if (!other.transform.parent.tag.Equals("Player")) return;
        
        if (this.time > 0) return;

        this.time = this.timeDelay;
        this.SendByTransform(other.transform.parent);
    }

    public virtual void SendByTransform(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null)
            return;
        this.SendByDamageReceiver(damageReceiver);
    }

    public virtual void SendByDamageReceiver(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(damage);
    }
}
