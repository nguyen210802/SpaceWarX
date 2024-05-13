using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCtrl : ShootableObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Boss.ToString();
    }
}
