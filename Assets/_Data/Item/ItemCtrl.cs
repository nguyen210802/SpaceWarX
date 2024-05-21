using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn GetItemDespawn => itemDespawn;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
    }

    protected override void OnEnable()
    {
        base.OnEnable();
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": Load ItemDespawn", gameObject);
    }
}
