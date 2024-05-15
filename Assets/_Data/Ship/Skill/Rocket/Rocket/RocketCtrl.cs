using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected RocketDespawn rocketDespawn;
    public RocketDespawn GetRocketDespawn => rocketDespawn;

    [SerializeField] protected RocketDamageSender rocketDamageSender;
    public RocketDamageSender GetRocketDamageSender => rocketDamageSender;

    [SerializeField] protected RocketUpgrade rocketUpgrade;
    public RocketUpgrade GetBulletUpgrade => rocketUpgrade;

    [SerializeField] protected Transform shooter;
    public Transform GetShooter => shooter;

    [SerializeField] protected Transform explotion;
    public Transform GetExplotion => explotion;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageSender();
        this.LoadRocketDespawn();
        this.LoadRocketUpgrade();
        this.LoadShooter();
        this.LoadExplotion();
    }

    protected virtual void LoadDamageSender()
    {
        if (this.rocketDamageSender != null) return;
        this.rocketDamageSender = transform.GetComponentInChildren<RocketDamageSender>();
        Debug.Log(transform.name + ": LoadDamageSender", gameObject);
    }

    protected virtual void LoadRocketDespawn()
    {
        if (this.rocketDespawn != null) return;
        this.rocketDespawn = transform.GetComponentInChildren<RocketDespawn>();
        Debug.Log(transform.name + ": LoadBulletDespawn", gameObject);
    }

    protected virtual void LoadRocketUpgrade()
    {
        if (this.rocketUpgrade != null) return;
        this.rocketUpgrade = transform.GetComponentInChildren<RocketUpgrade>();
        Debug.Log(transform.name + ": LoadRocketUpgrade", gameObject);
    }

    protected virtual void LoadShooter()
    {
        if (this.shooter != null) return;
        this.shooter = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadShooter", gameObject);
    }

    protected virtual void LoadExplotion()
    {
        if (this.explotion != null) return;
        this.explotion = transform.parent.Find("Explotion");
        Debug.Log(transform.name + ": LoadExplotion");
    }
}
