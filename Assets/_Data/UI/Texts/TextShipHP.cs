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
        float hp = ShipCtrl.Instance.GetDamageReceiver.GetHp;
        float maxHp = ShipCtrl.Instance.GetDamageReceiver.GetMaxHp;
        this.text.SetText((int)hp+"/"+(int)maxHp);
        
    }
}
