using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageReceiver : ShootableObjectDamageReceiver
{
    protected override void OnDead()
    {
        base.OnDead();
        this.OnDeadFX();
        GameCtrl.Instance.GetGameWave.PlayerDespawn();
        this.shootableObjectCtrl.GetDespawn.DespawnObject();
    }

    protected override string GetOnDeadFXSmoke()
    {
        return FXSpawner.Instance.explotion;
    }
}
