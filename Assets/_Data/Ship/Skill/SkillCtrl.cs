using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;
    public ShipCtrl GetShipCtrl => shipCtrl;

    [SerializeField] protected SkillInvisible skillInvisible;
    public SkillInvisible GetSkillInvisible => skillInvisible;

    [SerializeField] protected SkillLaser skillLaser;
    public SkillLaser GetSkillLaser => skillLaser;

    [SerializeField] protected SkillRocket skillRocket;
    public SkillRocket GetSkillRocket => skillRocket;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
        this.LoadSkillInvisible();
        this.LoadSkillLaser();
        this.LoadSkillRocket();
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + "LoadShipCtrl", gameObject);
    }

    protected virtual void LoadSkillInvisible()
    {
        if (this.skillInvisible != null) return;
        this.skillInvisible = transform.GetComponentInChildren<SkillInvisible>();
        Debug.Log(transform.name + "LoadSkillInvisible", gameObject);
    }

    protected virtual void LoadSkillLaser()
    {
        if (this.skillLaser != null) return;
        this.skillLaser = transform.GetComponentInChildren<SkillLaser>();
        Debug.Log(transform.name + "LoadSkillLaser", gameObject);
    }

    protected virtual void LoadSkillRocket()
    {
        if (this.skillRocket != null) return;
        this.skillRocket = transform.GetComponentInChildren<SkillRocket>();
        Debug.Log(transform.name + "LoadSkillRocket", gameObject);
    }
}
