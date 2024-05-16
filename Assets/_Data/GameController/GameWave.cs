using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameWave : NguyenMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;

    [SerializeField] protected List<Wave> gameWaves;
    [SerializeField] protected int currentWave = 0;
    [SerializeField] protected float timeNext = 0f;

    [SerializeField] protected float timeDelay = 2f;

    [SerializeField] protected bool spawnedBoss = false;
    [SerializeField] protected bool gameWin = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
    }

    protected virtual void LoadGameCtrl()
    {
        if (gameCtrl != null) return;
        this.gameCtrl = transform.parent.GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }

    protected override void Start()
    {
        if (gameWaves.Count == 0)
        {
            Debug.Log("gameWaves = 0");
            return;
        }
        this.SetValueSpawner();
        this.timeNext = gameWaves[currentWave + 1].timeStart;
    }

    private void Update()
    {
        if (currentWave >= gameWaves.Count - 1) return;
        if (gameCtrl.GetTime >= gameWaves[currentWave + 1].timeStart)
        {
            this.currentWave++;
            this.SetValueSpawner();
            if (currentWave < gameWaves.Count - 1)
                this.timeNext = gameWaves[currentWave + 1].timeStart;
        }
    }

    private void FixedUpdate()
    {
        if (this.currentWave >= this.gameWaves.Count - 1 && this.gameWin == false)
            this.CheckSpawnedBoss();
    }

    protected virtual void CheckSpawnedBoss()
    {
        if (this.spawnedBoss == true)
            this.CheckGameWin();
        if (BossSpawner.Instance.GetSpawnedCount != 0)
            this.spawnedBoss = true;
    }

    protected virtual void CheckGameWin()
    {
        if (gameCtrl.GetTime >= gameCtrl.GetTimeFinish && BossSpawner.Instance.GetSpawnedCount <= 0)
        {
            Debug.Log("GameWin");
            this.gameWin = true;
            Invoke("GameWin", this.timeDelay);
        }
    }

    public void PlayerDespawn()
    {
        Debug.Log("GameOver");
        Invoke("GameOver", this.timeDelay);
    }

    protected virtual void GameWin()
    {
        Time.timeScale = 0f;
    }
    protected virtual void GameOver()
    {
        Time.timeScale = 0f;
    }

    protected virtual void SetValueSpawner()
    {
        SetValueJunkSpawner();
        SetValueEnemySpawner();
        SetValueMotherShipSpawner();
        SetValueBossSpawner();
    }

    protected virtual void SetValueJunkSpawner()
    {
        JunkSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].junkDelay);
        JunkSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].junkLimit);
        JunkSpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].junkTotalLimit);
    }

    protected virtual void SetValueEnemySpawner()
    {
        EnemySpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].enemyDelay);
        EnemySpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].enemyLimit);
        EnemySpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].enemyTotalLimit);
    }

    protected virtual void SetValueMotherShipSpawner()
    {
        MotherShipSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].motherShipDelay);
        MotherShipSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].motherShipLimit);
        MotherShipSpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].motherShipTotalLimit);
    }

    protected virtual void SetValueBossSpawner()
    {
        BossSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].bossDelay);
        BossSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].bossLimit);
        BossSpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].bossTotalLimit);
    }
}
