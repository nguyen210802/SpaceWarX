using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class BulletCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected Despawn bulletDespawn;
    public Despawn GetBulletDespawn => bulletDespawn;

    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender GetBulletDamageSender => bulletDamageSender;

    [SerializeField] protected BulletUpgrade bulletUpgrade;
    public BulletUpgrade GetBulletUpgrade => bulletUpgrade;

    [SerializeField] protected Transform shooter;
    public Transform GetShooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletUpgrade();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.bulletDamageSender != null) return;
        this.bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.bulletDespawn != null) return;
        this.bulletDespawn = transform.GetComponentInChildren<Despawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    protected virtual void LoadBulletUpgrade()
    {
        if (this.bulletUpgrade != null) return;
        this.bulletUpgrade = transform.GetComponentInChildren<BulletUpgrade>();
        Debug.Log(transform.name + ": LoadBulletUpgrade", gameObject);
    }

    public virtual void SetShotter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
