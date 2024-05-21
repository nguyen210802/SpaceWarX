using UnityEngine;

public class ColliderDamageReceiver : NguyenMonoBehaviour
{
    [SerializeField] protected DamageReceiver damageReceiver;
    [SerializeField] protected float damageReceive = 1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = GetComponent<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.CompareTag("Enemy"))
        {
            damageReceiver.Deduct(damageReceive);
        }
    }
}
