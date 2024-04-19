using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abilities : NguyenMonoBehaviour
{
    [Header("Abilities")]

    [SerializeField] protected AbilityObjectCtrl abilityObjectCtrl;
    public AbilityObjectCtrl GetAbilityObjectCtrl => abilityObjectCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectCtrl();
    }

    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjectCtrl != null) return;
        this.abilityObjectCtrl = transform.parent.GetComponent<AbilityObjectCtrl>();
        Debug.Log(transform.name + ": LoadAbilityObjectCtrl", gameObject);
    }
}
