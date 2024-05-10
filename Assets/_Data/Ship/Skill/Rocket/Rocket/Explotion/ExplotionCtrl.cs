using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected ExplotionDespawn expDespawn;
    public ExplotionDespawn GetExpDespawn => expDespawn;

    [SerializeField] protected ExplotionDamageSender expDamageSender;
    public ExplotionDamageSender GetExpDamageSender => expDamageSender;

    [SerializeField] protected ExplotionUpgrade expUpgrade;
    public ExplotionUpgrade GetExpUpgrade => expUpgrade;

    [SerializeField] protected Transform shooter;
    public Transform GetShooter => shooter;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadBulletDespawn();
        this.LoadBulletUpgrade();
        this.LoadShooter();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.expDamageSender != null) return;
        this.expDamageSender = transform.GetComponentInChildren<ExplotionDamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadBulletDespawn()
    {
        if (this.expDespawn != null) return;
        this.expDespawn = transform.GetComponentInChildren<ExplotionDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    protected virtual void LoadBulletUpgrade()
    {
        if (this.expUpgrade != null) return;
        this.expUpgrade = transform.GetComponentInChildren<ExplotionUpgrade>();
        Debug.Log(transform.name + ": LoadBulletUpgrade", gameObject);
    }

    protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadShooter", gameObject);
    }
}
