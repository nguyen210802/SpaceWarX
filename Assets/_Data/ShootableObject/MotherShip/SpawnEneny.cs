using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEneny : NguyenMonoBehaviour
{
    [SerializeField] protected MotherShipCtrl motherShipCtrl;

    [SerializeField] protected float timeDelay = 2f;
    [SerializeField] protected float timer;

    [SerializeField] protected EnemySpawner enemySpawner;

    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMotherShipCtrl();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadMotherShipCtrl()
    {
        if (this.motherShipCtrl != null) return;
        this.motherShipCtrl = transform.parent.GetComponent<MotherShipCtrl>();
        Debug.Log(transform.name + ": LoadMotherShipCtrl", gameObject);
    }
    protected virtual void LoadEnemySpawner()
    {
        if (this.enemySpawner != null) return;
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        this.enemySpawner = enemySpawner.GetComponent<EnemySpawner>();
        Debug.Log(transform.name + ": LoadAbilities", gameObject);
    }

    private void FixedUpdate()
    {
        this.Spawning();
        this.ClearDeadMinions();
    }

    protected virtual void Spawning()
    {
        if (!this.Timing()) return;
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        if (this.minions.Count >= this.minionLimit) return;
        
        Transform spawnPos = motherShipCtrl.GetSpawnPoints.GetRanDom();

        Transform minionPrefab = this.enemySpawner.RandomPrefab();
        Transform minion = this.enemySpawner.SpawnByTransform(minionPrefab, spawnPos.position, transform.rotation);

        Transform minionObjAppearing = minion.Find("ObjAppearing");
        minionObjAppearing.gameObject.SetActive(true);
        minion.parent = motherShipCtrl.transform;
        this.minions.Add(minion);
        minion.gameObject.SetActive(true);

        this.timer = 0f;
    }

    protected virtual bool Timing()
    {
        this.timer += Time.fixedDeltaTime;
        if(this.timer >= this.timeDelay)
        {
            this.timer = this.timeDelay;
            return true;
        }
        return false;
    }

    protected virtual void ClearDeadMinions()
    {
        for(int i=0; i<this.minions.Count; i++)
        {
            if (minions[i].gameObject.activeSelf == false)
                this.minions.Remove(minions[i]);
        }
    }
}
