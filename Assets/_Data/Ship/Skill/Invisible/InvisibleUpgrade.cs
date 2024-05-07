using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisibleUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected SkillInvisible invisibleCtrl;

    [SerializeField] protected float valueCritTimeBonus = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInvisibleCtrl();
    }

    protected virtual void LoadInvisibleCtrl()
    {
        if (this.invisibleCtrl != null) return;
        this.invisibleCtrl = transform.parent.GetComponent<SkillInvisible>();
        Debug.Log(transform.name + ": LoadInvisibleCtrl", gameObject);
    }

    private void Update()
    {
        this.UpgradeByLevel();
    }

    public virtual void UpgradeByLevel()
    {
        float newCritTimeBonus = ShipUpgrade.Instance.GetCurrentLevel * valueCritTimeBonus;
        invisibleCtrl.GetInvisible.SetCritTimeBonus(newCritTimeBonus);
    }
}
