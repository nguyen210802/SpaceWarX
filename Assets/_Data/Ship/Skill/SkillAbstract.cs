using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillAbstract : NguyenMonoBehaviour
{
    [SerializeField] protected SkillCtrl skillCtrl;
    public SkillCtrl GetSkillCtrl => skillCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSkillCtrl();
    }

    protected virtual void LoadSkillCtrl()
    {
        if (this.skillCtrl != null) return;
        this.skillCtrl = transform.parent.GetComponent<SkillCtrl>();
        Debug.Log(transform.name + "LoadSkillCtrl", gameObject);
    }
}
