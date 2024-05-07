using System;
using UnityEngine;

[Serializable]
public class ItemDropRate
{
    public ItemProfileSO itemProfile;
    public int dropValue = 70;
    public int minDrop = 0;
    public int maxDrop = 100;
}
