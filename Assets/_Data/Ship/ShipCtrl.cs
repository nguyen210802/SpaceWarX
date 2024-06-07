using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : ShootableObjectCtrl
{
    private static ShipCtrl instance;
    public static ShipCtrl Instance => instance;

    [Header("Ship Ctrl")]
    
    [SerializeField] protected ShipUpgrade shipUpgrade;
    public ShipUpgrade GetShipUpgrade => shipUpgrade;

    [SerializeField] protected SkillCtrl skillCtrl;
    public SkillCtrl GetSkillCtrl => skillCtrl;

    protected override void Awake()
    {
        base.Awake();
        ShipCtrl.instance = this;
    }

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipUpgrade();
        this.LoadSkillCtrl();
    }

    protected virtual void LoadShipUpgrade()
    {
        if (this.shipUpgrade != null) return;
        this.shipUpgrade = transform.GetComponentInChildren<ShipUpgrade>();
        Debug.Log(transform.name + ": LoadShipUpgrade", gameObject);
    }

    protected virtual void LoadSkillCtrl()
    {
        if (this.skillCtrl != null) return;
        this.skillCtrl = transform.GetComponentInChildren<SkillCtrl>();
        Debug.Log(transform.name + ": LoadSkillCtrl", gameObject);
    }

    protected override void LoadMonsterDamageSender(){}
}
