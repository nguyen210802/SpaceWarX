using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : NguyenMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;

    [SerializeField] protected Camera mainCamera;
    public Camera GetMainCamera => mainCamera;

    [SerializeField] protected float time = 0f;
    [SerializeField] protected float timeFinish = 30f;

    [SerializeField] protected List<GameWave> gameWaves;
    [SerializeField] protected int nextValueWave = 0;
    [SerializeField] protected float timeNext = 0f;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) 
            Debug.LogError("Only 1 GameManager alow to");
        GameCtrl.instance = this;
    }

    protected override void Start()
    {
        //JunkSpawnerRandom.Instance.SetRandomLimit(1);
        //JunkSpawner

        //EnemySpawnerRandom.Instance.SetRandomLimit(2);



        //MotherShipSpawnerRandom.Instance.SetRandomLimit(3);
    }

    private void Update()
    {
        if (nextValueWave >= gameWaves.Count - 1) return;
        if (this.time >= gameWaves[nextValueWave].timeStart)
        {
            nextValueWave++;
            this.timeNext = gameWaves[nextValueWave].timeStart;
        }
            
    }

    private void FixedUpdate()
    {
        this.TimeGame();
    }

    protected virtual void TimeGame()
    {
        this.time += Time.fixedDeltaTime;
        if(this.time >= this.timeFinish)
        {
            this.time = this.timeFinish;
            Time.timeScale = 0f;
        }
    }

    protected virtual void GameOver()
    {

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCamera();
    }

    protected virtual void LoadCamera()
    {
        if (this.mainCamera != null) return;
        this.mainCamera = GameCtrl.FindObjectOfType<Camera>();
        Debug.Log(gameObject.name + "LoadCamera", gameObject);
    }
}
