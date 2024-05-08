using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : ShootableObjectCtrl
{
    [Header("Ship Ctrl")]
    [SerializeField] protected Inventory inventory;
    public Inventory GetInventory => inventory;
    
    [SerializeField] protected ShipUpgrade shipUpgrade;
    public ShipUpgrade GetShipUpgrade => shipUpgrade;

    [SerializeField] protected SkillCtrl skillCtrl;
    public SkillCtrl GetSkillCtrl => skillCtrl;

    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver GetDamageReceiver => damageReceiver;

    protected override string GetObjectTypeString()
    {
        return ObjectType.Ship.ToString();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageReceiver();
        this.LoadInventory();
        this.LoadShipUpgrade();
        this.LoadSkillCtrl();
    }

    protected virtual void LoadDamageReceiver()
    {
        if (this.damageReceiver != null) return;
        this.damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
        Debug.Log(transform.name + ": LoadDamageReceiver", gameObject);
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.GetComponentInChildren<Inventory>();
        Debug.Log(transform.name + ": LoadInventory", gameObject);
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
}
