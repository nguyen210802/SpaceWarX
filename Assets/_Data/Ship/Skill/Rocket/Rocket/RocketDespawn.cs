using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketDespawn : NguyenMonoBehaviour
{
    [SerializeField] protected RocketCtrl rocketCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRocketCtrl();
    }

    protected virtual void LoadRocketCtrl()
    {
        if (this.rocketCtrl != null) return;
        this.rocketCtrl = transform.parent.GetComponent<RocketCtrl>();
        Debug.Log(transform.name + ": LoadRocketCtrl", gameObject);
    }

    public virtual void DespawnObject()
    {
        this.CreateExp();
        AudioManager.Instance.PlaySfx(AudioManager.Instance.explotionAudioClip);
        BulletSpawner.Instance.Despawn(transform.parent);
    }

    protected virtual void CreateExp()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.explotion, spawnPos, rotation);
        if (newBullet == null)
            return;

        newBullet.gameObject.SetActive(true);
    }
}
