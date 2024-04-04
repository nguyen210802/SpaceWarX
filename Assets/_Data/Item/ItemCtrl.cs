using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
        this.ResetItem();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": Load ItemDespawn", gameObject);
    }

    protected virtual void LoadItemInventory()
    {
        if(this.itemInventory.itemProfile != null) return;

        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemProfileSO itemProfile = ItemProfileSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        this.ResetItem();
        this.itemInventory.maxStack = itemProfile.defaultMaxStack;
    }

    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory.Clone();
    }

    protected virtual void ResetItem()
    {
        this.ItemInventory.itemCount = 1;
        this.itemInventory.upgradeLevel = 0;
    }
}
