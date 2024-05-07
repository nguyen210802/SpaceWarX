using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipUpgrade : NguyenMonoBehaviour
{
    [SerializeField] protected ShipCtrl shipCtrl;

    private static ShipUpgrade instance;
    public static ShipUpgrade Instance => instance;

    [SerializeField] protected int currentLevel = 2;
    public int GetCurrentLevel => currentLevel;
    [SerializeField] protected int maxLevel = 9;

    protected override void Awake()
    {
        base.Awake();
        ShipUpgrade.instance = this;
    }

    //protected override void Start()
    //{
    //    shipCtrl.GetSkillCtrl.GetSkillInvisible.GetInvisibleUpgrade.UpgradeByLevel(currentLevel);

    //    LaserCtrl laserCtrl = shipCtrl.GetSkillCtrl.GetSkillLaser.GetLaser.GetComponent<LaserCtrl>();
    //    laserCtrl.GetLaserUpgrade.UpgradeByLevel(2);
    //}

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShipCtrl();
    }

    protected virtual void LoadShipCtrl()
    {
        if (this.shipCtrl != null) return;
        this.shipCtrl = transform.parent.GetComponent<ShipCtrl>();
        Debug.Log(transform.name + ": LoadShipCtrl", gameObject);
    }
}
