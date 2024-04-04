using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShootableObject", menuName = "SO/ShootableObject")]

public class ShootableObjectSO : ScriptableObject
{
    public string junkName = "Junk";
    public int maxHp = 2;
    public List<DropRate> dropList;
}
