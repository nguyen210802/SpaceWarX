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
        if (this.currentWave >= this.gameWaves.Count - 1)
            this.CheckGameWin();
    }

    protected virtual void CheckGameWin()
    {
        if (gameCtrl.GetTime >= gameCtrl.GetTimeFinish + 5f && BossSpawner.Instance.GetSpawnedCount <= 0)
        {
            AudioManager.Instance.PlayMusic(AudioManager.Instance.gameWinAudioClip);
            Invoke("GameWin", 2f);
        }
    }

    public void PlayerDespawn()
    {
        Debug.Log("GameOver");
        AudioManager.Instance.PlayMusic(AudioManager.Instance.gameOverAudioClip);
        Invoke("GameOver", 2f);
    }

    protected virtual void SetValueSpawner()
    {
        SetValueJunkSpawner();
        SetValueEnemySpawner();
        SetValueSniperSpawner();
        SetValueMotherShipSpawner();
        if (this.currentWave == gameWaves.Count - 1)
            Invoke("SetValueBossSpawner", 2f);
    }

    protected virtual void SetValueJunkSpawner()
    {
        GameObject junkSpawner = GameObject.Find("EnemySpawner");
        if (junkSpawner == null) return;

        JunkSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].junkWave.junkDelay);
        JunkSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].junkWave.junkLimit);
    }

    protected virtual void SetValueEnemySpawner()
    {
        GameObject enemySpawner = GameObject.Find("EnemySpawner");
        if (enemySpawner == null) return;

        EnemySpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].enemyWave.enemyDelay);
        EnemySpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].enemyWave.enemyLimit);
    }

    protected virtual void SetValueSniperSpawner()
    {
        GameObject sniperSpawner = GameObject.Find("SniperSpawner");
        if (sniperSpawner == null) return;

        SniperSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].sniperWave.sniperDelay);
        SniperSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].sniperWave.sniperLimit);
    }

    protected virtual void SetValueMotherShipSpawner()
    {
        GameObject motherShipSpawner = GameObject.Find("MotherShipSpawner");
        if (motherShipSpawner == null) return;

        MotherShipSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].motherShipWave.motherShipDelay);
        MotherShipSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].motherShipWave.motherShipLimit);
    }

    protected virtual void SetValueBossSpawner()
    {
        GameObject[] allEnemy = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject enemy in allEnemy)
        {
            if (enemy.activeSelf)
                enemy.SetActive(false);
        }

        GameObject bossSpawner = GameObject.Find("BossSpawner");
        if (bossSpawner == null) return;

        BossSpawnerRandom.Instance.SetSpawnDelay(gameWaves[currentWave].bossWave.bossDelay);
        BossSpawnerRandom.Instance.SetSpawnLimit(gameWaves[currentWave].bossWave.bossLimit);
        BossSpawnerRandom.Instance.SetTotalSpawnLimit(gameWaves[currentWave].bossWave.bossTotalLimit);
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
