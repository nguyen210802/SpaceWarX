using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : NguyenMonoBehaviour
{
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null)
            return;
        this.Send(damageReceiver);
        this.CreateFXImpact();
    }

    public virtual void Send(DamageReceiver damageReceiver) 
    {
        damageReceiver.Deduct(this.damage);
    }

    protected virtual void CreateFXImpact()
    {
        string fxName = this.GetImpactFX();
        Vector3 hitPos = transform.parent.position;
        Quaternion hitRot = transform.parent.rotation;
        Transform FXImpact = FXSpawner.Instance.Spawn(fxName, hitPos, hitRot);
        FXImpact.gameObject.SetActive(true);
    }

    protected virtual string GetImpactFX()
    {
        return FXSpawner.Instance.impact1;
    }
}
