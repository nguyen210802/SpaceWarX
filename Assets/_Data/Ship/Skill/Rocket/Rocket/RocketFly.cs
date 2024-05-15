using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketFly : ParentFly
{
    [Header("Rocket Fly")]
    [SerializeField] protected RocketCtrl rocketCtrl;

    [SerializeField] protected Vector3 posStart;
    [SerializeField] protected float distanceFly;
    [SerializeField] protected float distanceExplotion = 6;

    protected override void ResetValue()
    {
        base.ResetValue();
        this.moveSpeed = 10;
    }

    private void FixedUpdate()
    {
        this.ExpRocket();
    }

    protected virtual void ExpRocket()
    {
        this.distanceFly = Vector3.Distance(posStart, transform.parent.position);
        if (this.distanceFly >= this.distanceExplotion)
        {
            //this.CreateExp();
            rocketCtrl.GetRocketDespawn.DespawnObject();
        }
    }

    protected virtual void CreateExp()
    {
        Vector3 spawnPos = transform.parent.position;
        Quaternion rotation = transform.parent.rotation;
        Transform newBullet = BulletSpawner.Instance.SpawnByName(BulletSpawner.Instance.explotion, spawnPos, rotation);
        if (newBullet == null)
            return;

        newBullet.gameObject.SetActive(true);

        rocketCtrl.GetRocketDespawn.DespawnObject();
    }

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

    public virtual void SetPosStart(Vector3 pos)
    {
        this.posStart = pos;
    }
}
