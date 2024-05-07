using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;

public class BulletCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender GetBulletDamageSender => bulletDamageSender;

    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn GetBulletDespawn => bulletDespawn;

    [SerializeField] protected Transform shooter;
    public Transform GetShooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
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
        this.bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    public virtual void SetShotter(Transform shooter)
    {
        this.shooter = shooter;
    }
}
