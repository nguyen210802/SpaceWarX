using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropSpawner : Spawner
{
    private static ItemDropSpawner instance;
    public static ItemDropSpawner Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (ItemDropSpawner.instance != null)
            Debug.LogError("Only 1 ItemDropSpawner allow to exit");
        ItemDropSpawner.instance = this;
    }
    
    public virtual void Drop(List<ItemDropRate> listDropItem, Vector3 pos, Quaternion rot)
    {
        if (listDropItem.Count == 0) return;

        ItemDropRate randomItemDrop = this.GetRandomItemDrop(listDropItem);

        if (randomItemDrop.itemProfile == null) return;
        if (!this.DropRate(randomItemDrop)) return;

        ItemCode itemCode = randomItemDrop.itemProfile.itemCode;
        Transform itemDrop = this.SpawnByName(itemCode.ToString(), pos, rot);
        if (itemDrop == null) return;
        itemDrop.gameObject.SetActive(true);
    }

    public virtual bool DropRate(ItemDropRate dropRate)
    {
        float randomDropValue = Random.Range(dropRate.minDrop, dropRate.maxDrop);
        return dropRate.dropValue >= randomDropValue;
    }

    public virtual ItemDropRate GetRandomItemDrop(List<ItemDropRate> dropList)
    {
        int valueItemDrop = Random.Range(0, dropList.Count);
        return dropList[valueItemDrop];
    }
}
