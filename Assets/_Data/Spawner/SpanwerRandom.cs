using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpanwerRandom : NguyenMonoBehaviour
{
    [Header("Spawn Random")]
    [SerializeField] protected SpawnerCtrl spawnerCtrl;
    [SerializeField] protected float randomDelay = 1f;
    [SerializeField] protected float randomTime = 0f;
    [SerializeField] protected float randomLimit = 9;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnerCtrl();
    }
    protected virtual void LoadSpawnerCtrl()
    {
        if (this.spawnerCtrl != null) return;
        this.spawnerCtrl = GetComponent<SpawnerCtrl>();
        Debug.Log(transform.name + ": LoadSpawnerCtrl", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.Spawning();
    }

    protected virtual void Spawning()
    {
        if (this.RandomReachLimit()) return;

        this.randomTime += Time.fixedDeltaTime;
        if (this.randomTime < this.randomDelay) return;
        this.randomTime = 0f;

        Transform randomPoint = this.spawnerCtrl.GetSpawnPoints.GetRanDom();
        Vector3 pos = randomPoint.position;
        Quaternion rot = transform.rotation;

        Transform prefab = this.spawnerCtrl.GetSpawner.RandomPrefab();
        Transform obj = this.spawnerCtrl.GetSpawner.Spawn(prefab, pos, rot);
        obj.gameObject.SetActive(true);
    }

    protected virtual bool RandomReachLimit()
    {
        int currenJunk = this.spawnerCtrl.GetSpawner.GetSpawnedCount;
        return currenJunk >= this.randomLimit;
    }
}
