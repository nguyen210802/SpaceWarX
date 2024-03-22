using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 1f;
    [SerializeField] protected float shootTimer = 0f;


    private void Update()
    {
        this.IsShooting();
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        if (InputManager.Instance.OnPiring != 1)    return;

        if (Time.time < this.shootTimer) return;
        this.shootTimer = Time.time + this.shootDelay;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBuller = BulletSpawner.Instance.Spawn(BulletSpawner.Instance.bulletOne, spawnPos, rotation);
        if (newBuller == null)
            return;

        newBuller.gameObject.SetActive(true);
    }

    protected virtual bool IsShooting()
    {
        this.isShooting = InputManager.Instance.OnPiring == 1;
        return this.isShooting;
    }
}
