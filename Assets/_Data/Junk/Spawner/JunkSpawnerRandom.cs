using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SpawnerRandom
{
    private static JunkSpawnerRandom instance;
    public static JunkSpawnerRandom Instance => instance;

    //[SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    //[SerializeField] protected float randomDelay = 1f;
    //[SerializeField] protected float randomTime = 0f;
    //[SerializeField] protected float randomLimit = 9;
    //public void SetRandomLimit(int limit) { this.randomLimit = limit; }

    protected override void Awake()
    {
        base.Awake();
        JunkSpawnerRandom.instance = this;
    }

    //protected override void LoadComponents()
    //{
    //    base.LoadComponents();
    //    this.LoadJunkSpawnerCtrl();
    //}
    //protected virtual void LoadJunkSpawnerCtrl()
    //{
    //    if (this.junkSpawnerCtrl != null) return;
    //    this.junkSpawnerCtrl = GetComponent<JunkSpawnerCtrl>();
    //    Debug.Log(transform.name + ": Load JunkCtrl", gameObject);
    //}

    //protected virtual void FixedUpdate()
    //{
    //    this.JunkSpawning();
    //}

    //protected virtual void JunkSpawning()
    //{
    //    if (this.RandomReachLimit()) return;

    //    this.randomTime += Time.fixedDeltaTime;
    //    if (this.randomTime < this.randomDelay) return;
    //    this.randomTime = 0f;

    //    Transform randomPoint = this.junkSpawnerCtrl.JunkSpawnPoints.GetRanDom();
    //    Vector3 pos = randomPoint.position;
    //    Quaternion rot = transform.rotation;

    //    Transform prefab = this.junkSpawnerCtrl.JunkSpawner.RandomPrefab();
    //    Transform obj = this.junkSpawnerCtrl.JunkSpawner.SpawnByTransform(prefab, pos, rot);
    //    obj.gameObject.SetActive(true);
    //}

    //protected virtual bool RandomReachLimit()
    //{
    //    int currenJunk = this.junkSpawnerCtrl.JunkSpawner.GetSpawnedCount;
    //    return currenJunk >= this.randomLimit;
    //}
}