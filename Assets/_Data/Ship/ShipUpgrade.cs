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
    [SerializeField] protected int upgradePoint;
    [SerializeField] protected int nextUpgradePoint;

    protected override void Awake()
    {
        base.Awake();
        ShipUpgrade.instance = this;
    }

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

    public void AddUpgradePoint(int point)
    {
        this.upgradePoint += point;
    }

    public void checkUpgrade()
    {
        if(this.upgradePoint >= this.nextUpgradePoint && this.currentLevel < this.maxLevel)
        {
            this.upgradePoint -= this.nextUpgradePoint;
            this.UpgradeLevel();
        }
    }

    public void UpgradeLevel()
    {
        this.currentLevel++;
        if (this.currentLevel >= this.maxLevel)
            this.currentLevel = this.maxLevel;
    }
}
