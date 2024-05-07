using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillInvisible : SkillAbstract
{
    [SerializeField] protected Invisible invisible;
    public Invisible GetInvisible => invisible;

    [SerializeField] protected InvisibleUpgrade invisibleUpgrade;
    public InvisibleUpgrade GetInvisibleUpgrade => invisibleUpgrade;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInvisible();
        this.LoadInvisibleUpgrade();
    }

    protected virtual void LoadInvisible()
    {
        if (this.invisible != null) return;
        this.invisible = transform.GetComponentInChildren<Invisible>();
        Debug.Log(transform.name + ": LoadInvisible", gameObject);
    }

    protected virtual void LoadInvisibleUpgrade()
    {
        if (this.invisibleUpgrade != null) return;
        this.invisibleUpgrade = transform.GetComponentInChildren<InvisibleUpgrade>();
        Debug.Log(transform.name + ": LoadInvisibleUpgrade", gameObject);
    }
}
