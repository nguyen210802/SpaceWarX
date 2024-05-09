using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderKeywordFilter;
using UnityEngine;

public class ColliderWithEnemy : NguyenMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    [SerializeField] protected float damageReceive = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShipCtrl", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Enemy"))
        {
            Debug.Log("Nguyen");
            shipCtrl.GetDamageReceiver.Deduct(damageReceive);
        }
    }
}
