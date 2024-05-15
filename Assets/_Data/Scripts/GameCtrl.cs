using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : NguyenMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;

    [SerializeField] protected Transform player;

    [SerializeField] protected Camera mainCamera;
    public Camera GetMainCamera => mainCamera;

    [SerializeField] protected float time = 0f;
    [SerializeField] protected float timeFinish = 30f;

    [SerializeField] protected int mapLevel = 0;
    public int GetMapLevel => mapLevel;
    [SerializeField] protected int countMapLevel = 5;
    [SerializeField] protected float timeNextLevel;

    [SerializeField] protected List<GameWave> gameWaves;
    [SerializeField] protected int valueWave = 0;
    [SerializeField] protected float timeNext = 0f;

    [SerializeField] protected float timeDelay = 3f;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) 
            Debug.LogError("Only 1 GameManager alow to");
        GameCtrl.instance = this;

        this.timeNextLevel = this.timeFinish / this.countMapLevel;
    }

    protected override void Start()
    {
        if(gameWaves.Count == 0)
        {
            Debug.Log("gameWaves = 0");
            return;
        }
        this.SetValueSpawner();
        this.timeNext = gameWaves[valueWave + 1].timeStart;
    }

    protected virtual void SetValueSpawner()
    {
        JunkSpawnerRandom.Instance.SetSpawnDelay(gameWaves[valueWave].junkDelay);
        JunkSpawnerRandom.Instance.SetSpawnLimit(gameWaves[valueWave].junkLimit);
        
        EnemySpawnerRandom.Instance.SetSpawnDelay(gameWaves[valueWave].enemyDelay);
        EnemySpawnerRandom.Instance.SetSpawnLimit(gameWaves[valueWave].enemyLimit);
        
        MotherShipSpawnerRandom.Instance.SetSpawnDelay(gameWaves[valueWave].motherShipDelay);
        MotherShipSpawnerRandom.Instance.SetSpawnLimit(gameWaves[valueWave].motherShipLimit);

        BossSpawnerRandom.Instance.SetSpawnDelay(gameWaves[valueWave].motherShipDelay);
        BossSpawnerRandom.Instance.SetSpawnLimit(gameWaves[valueWave].motherShipLimit);
    }

    private void Update()
    {
        if (valueWave >= gameWaves.Count - 1) return;
        if (this.time >= gameWaves[valueWave + 1].timeStart)
        {
            valueWave++;
            this.SetValueSpawner();
            if (valueWave < gameWaves.Count - 1)
                this.timeNext = gameWaves[valueWave + 1].timeStart;
        }

    }

    private void FixedUpdate()
    {
        this.TimeGame();
        this.SetMapLevel();
        this.CheckGameWin();
    }

    protected virtual void TimeGame()
    {
        this.time += Time.fixedDeltaTime;
        if(this.time >= this.timeFinish)
            this.time = this.timeFinish;
    }

    protected virtual void SetMapLevel()
    {
        if (this.time >= timeNextLevel * this.mapLevel)
            this.mapLevel++;
    }

    protected virtual void CheckGameWin()
    {
        if(this.time >= this.timeFinish && BossSpawner.Instance.GetSpawnedCount <= 0)
        {
            Debug.Log("GameWin");
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

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadCamera();
    }

    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadShooter", gameObject);
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(gameObject.name + "LoadCamera", gameObject);
    }
}
