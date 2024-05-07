using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShipCtrl : AbilityObjectCtrl
{
    protected override string GetObjectTypeString()
    {
        return ObjectType.Enemy.ToString();
    }
}
