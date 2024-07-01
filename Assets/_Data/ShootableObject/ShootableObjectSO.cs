using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjectSO : ScriptableObject
{
    public int baseHp = 2;
    public float radius;
    public int point;
    public List<ItemDropRate> dropList;
    public List<int> listUpgradePoint;
}
