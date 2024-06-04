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
    public float GetTime => time;
    [SerializeField] protected float timeFinish = 120f;
    public float GetTimeFinish => timeFinish;

    [SerializeField] protected GameWave gameWave;
    public GameWave GetGameWave => gameWave;

    [SerializeField] protected GameMapLevel gameMapLevel;
    public GameMapLevel GetGameMapLevel => gameMapLevel;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) 
            Debug.LogError("Only 1 GameManager alow to");
        GameCtrl.instance = this;
    }

    private void FixedUpdate()
    {
        this.TimeGame();
    }

    protected virtual void TimeGame()
    {
        this.time += Time.fixedDeltaTime;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayer();
        this.LoadCamera();
        this.LoadGameWave();
        this.LoadGameMapLevel();
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

    protected virtual void LoadGameWave()
    {
        if (this.gameWave != null) return;
        this.gameWave = transform.GetComponentInChildren<GameWave>();
        Debug.Log(gameObject.name + "LoadGameWave", gameObject);
    }

    protected virtual void LoadGameMapLevel()
    {
        if (this.gameMapLevel != null) return;
        this.gameMapLevel = transform.GetComponentInChildren<GameMapLevel>();
        Debug.Log(gameObject.name + "LoadGameMapLevel", gameObject);
    }

}
