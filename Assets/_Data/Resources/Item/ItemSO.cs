using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "SO/Item")]

public class ItemSO : ScriptableObject
{
    public string itemCode = "code";
    public string itemName = "name";
}
