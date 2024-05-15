using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextShipHP : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateShipHP();
    }

    protected virtual void UpdateShipHP()
    {
        float hp = ShipCtrl.Instance.GetShootableObjectDamageReceiver.GetHp;
        float baseHp = ShipCtrl.Instance.GetShootableObjectDamageReceiver.GetBaseHp;
        this.text.SetText((int)hp+"/"+(int)baseHp);
        
    }
}
