using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : NguyenMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 2f;
    [SerializeField] protected float shootTimer = 0f;
    [SerializeField] protected string bulletName;
    public void SetBulletName (string name) { this.bulletName = name; }

    protected override void Start()
    {
        base.Start();
        bulletName = BulletSpawner.Instance.enemyBullet_1;
    }

    private void Update()
    {
        this.IsShooting();
    }

    private void FixedUpdate()
    {
        this.Shooting();
    }

    protected virtual void Shooting()
    {
        this.shootTimer += Time.fixedDeltaTime;

        if (!this.isShooting) return;
        if (this.shootTimer < this.shootDelay) return;
        this.shootTimer = 0f;

        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.SpawnByName(bulletName, spawnPos, rotation);
        if (newBullet == null)
            return;

        BulletCtrl bulletCtrl = newBullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShotter(transform.parent);

        newBullet.gameObject.SetActive(true);

        if (transform.parent.tag.Equals("Player"))
        {
            AudioManager.Instance.PlaySfx(AudioManager.Instance.fireAudioClip);
        }
    }

    protected abstract void IsShooting();
}
