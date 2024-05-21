using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestShooting : MonoBehaviour
{
    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    private void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.targetPosition = InputManager.Instance.GetMouseWorldPos;
        this.targetPosition.z = 0;
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        Vector3 diff = this.targetPosition - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        Quaternion targetEuler = Quaternion.Euler(0, 0, rot_z);

        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.parent.position;
        //Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.bullet1, spawnPos, targetEuler);
        if (newBullet == null)
            return;

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);

        newBullet.gameObject.SetActive(true);
    }

    protected virtual void IsShooting()
    {
        if (Input.GetMouseButton(0))
            this.isShooting = true;
        else
            this.isShooting = false;
    }
}
