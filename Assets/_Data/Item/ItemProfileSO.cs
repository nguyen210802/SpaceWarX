using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfileSO")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;
    public ItemType itemtype = ItemType.NoItem;
    public string itemName = "no-name";
    public int defaultMaxStack = 7;
    public List<ItemRecipe> upgradeLevels;

    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }
}
