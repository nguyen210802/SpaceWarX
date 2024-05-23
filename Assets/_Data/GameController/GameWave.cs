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

    [SerializeField] protected GameObject canvasGameWin;
    [SerializeField] protected GameObject canvasGameOver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadCanvasGameWin();
        this.LoadCanvasGameOver();
    }

    protected virtual void LoadGameCtrl()
    {
        if (gameCtrl != null) return;
        this.gameCtrl = transform.parent.GetComponent<GameCtrl>();
        Debug.Log(transform.name + ": LoadGameCtrl", gameObject);
    }
    protected virtual void LoadCanvasGameWin()
    {
        if (this.canvasGameWin != null) return;
        this.canvasGameWin = GameObject.Find("CanvasGameWin");
        Debug.Log(transform.name + ": LoadCanvasGameWin", gameObject);
    }
    protected virtual void LoadCanvasGameOver()
    {
        if (this.canvasGameWin != null) return;
        this.canvasGameWin = GameObject.Find("CanvasGameOver");
        Debug.Log(transform.name + ": LoadCanvasGameOver", gameObject);
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

    protected virtual void SetValueSpawner()
    {
        SetValueJunkSpawner();
        SetValueEnemySpawner();
        SetValueMotherShipSpawner();
        if (this.currentWave == gameWaves.Count - 1)
            Invoke("SetValueBossSpawner", 2f);
    }

    protected virtual void SetValueJunkSpawner()
    {
        JunkSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].junkDelay);
        JunkSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].junkLimit);
    }

    protected virtual void SetValueEnemySpawner()
    {
        EnemySpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].enemyDelay);
        EnemySpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].enemyLimit);
    }

    protected virtual void SetValueMotherShipSpawner()
    {
        MotherShipSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].motherShipDelay);
        MotherShipSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].motherShipLimit);
    }

    protected virtual void SetValueBossSpawner()
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in allEnemy)
        {
            if (enemy.activeSelf)
                enemy.SetActive(false);
        }

        BossSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].bossDelay);
        BossSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].bossLimit);
        BossSpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].bossTotalLimit);
    }

    protected virtual bool SetBossSpawner()
    {
        int enemyCount = EnemySpawner.Instance.GetSpawnedCount;
        int motherShipCount = MotherShipSpawner.Instance.GetSpawnedCount;
        if (enemyCount == 0 && motherShipCount == 0)
            return true;
        return false;
    }

    protected virtual void GameWin()
    {
        Time.timeScale = 0f;
        canvasGameWin.SetActive(true);
    }
    protected virtual void GameOver()
    {
        Time.timeScale = 0f;
        canvasGameOver.SetActive(true);
    }
}
