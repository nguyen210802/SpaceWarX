using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : NguyenMonoBehaviour
{
    protected AudioSource[] allAudioSources;
    private static AudioManager instance;
    public static AudioManager Instance => instance;

    [Header("AudioSource")]
    [SerializeField] protected AudioSource musicAudioSource;
    [SerializeField] protected AudioSource sfxAudioSource;

    
    [Header("AudioClip")]
    public AudioClip backgroundMapAudioClip;
    public AudioClip backgroundMenuAudioClip;
    public AudioClip despawnAudioClip;
    public AudioClip explotionAudioClip;
    public AudioClip fireAudioClip;
    public AudioClip gameWinAudioClip;
    public AudioClip gameOverAudioClip;
    public AudioClip laserAudioClip;
    public AudioClip rocketAudioClip;
    public AudioClip levelUpAudioClip;
    public AudioClip enemyDespawnAudioClip;
    public AudioClip receiverAudioClip;

    protected override void Awake()
    {
        base.Awake();
        if (AudioManager.instance != null)
            Debug.LogError("Only one AudioManager allow to exit!");
        AudioManager.instance = this;
    }

    protected override void LoadComponents()
    {
        this.LoadMusicAudioSource();
        this.LoadSfxAudioSource();

        this.LoadBackgroundMapAudioClip();
        this.LoadBackgroundMenuAudioClip();
        this.LoadDespawnAudioClip();
        this.LoadExplotionAudioClip();
        this.LoadFireAudioClip();
        this.LoadGameWinAudioClip();
        this.LoadGameOverAudioClip();
        this.LoadLaserAudioClip();
        this.LoadLevelUpAudioClip();
        this.LoadRocketAudioClip();
        this.LoadEnemyDespawnAudioClip();
        this.LoadReceiverAudioClip();
    }
    //AudioSource
    protected virtual void LoadMusicAudioSource()
    {
        if (this.musicAudioSource != null) return;
        GameObject music = transform.Find("Music").gameObject;
        this.musicAudioSource = music.GetComponent<AudioSource>();
        Debug.Log(transform.name + "LoadMusicAudioSource", gameObject);
    }
    protected virtual void LoadSfxAudioSource()
    {
        if (this.sfxAudioSource != null) return;
        GameObject sfx = transform.Find("Sfx").gameObject;
        this.sfxAudioSource = sfx.GetComponent<AudioSource>();
        Debug.Log(transform.name + "LoadSfxAudioSource", gameObject);
    }

    //AudioClip
    protected virtual void LoadBackgroundMapAudioClip()
    {
        if (this.backgroundMapAudioClip != null) return;
        string resPath = "Audio/backgroundMap";
        this.backgroundMapAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadBackgroundMapAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadBackgroundMenuAudioClip()
    {
        if (this.backgroundMenuAudioClip != null) return;
        string resPath = "Audio/backgroundMenu";
        this.backgroundMenuAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadBackgroundMenuAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadDespawnAudioClip()
    {
        if (this.despawnAudioClip != null) return;
        string resPath = "Audio/Despawn";
        this.despawnAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadDespawnAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadExplotionAudioClip()
    {
        if (this.explotionAudioClip != null) return;
        string resPath = "Audio/Explotion";
        this.explotionAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadExplotionAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadFireAudioClip()
    {
        if (this.fireAudioClip != null) return;
        string resPath = "Audio/fire";
        this.fireAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadFireAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadGameWinAudioClip()
    {
        if (this.gameWinAudioClip != null) return;
        string resPath = "Audio/Gamewin";
        this.gameWinAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadGameWinAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadGameOverAudioClip()
    {
        if (this.gameOverAudioClip != null) return;
        string resPath = "Audio/Gameover";
        this.gameOverAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadGameOverAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadLaserAudioClip()
    {
        if (this.laserAudioClip != null) return;
        string resPath = "Audio/Laser";
        this.laserAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadLaserAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadLevelUpAudioClip()
    {
        if (this.levelUpAudioClip != null) return;
        string resPath = "Audio/levelUp";
        this.levelUpAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadLevelUpAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadRocketAudioClip()
    {
        if (this.rocketAudioClip != null) return;
        string resPath = "Audio/Rocket";
        this.rocketAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadRocketAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadEnemyDespawnAudioClip()
    {
        if (this.enemyDespawnAudioClip != null) return;
        string resPath = "Audio/EnemyDespawn";
        this.enemyDespawnAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadEnemyDespawnAudioClip" + resPath, gameObject);
    }
    protected virtual void LoadReceiverAudioClip()
    {
        if (this.receiverAudioClip != null) return;
        string resPath = "Audio/Receiver";
        this.receiverAudioClip = Resources.Load<AudioClip>(resPath);
        Debug.Log(transform.name + ": LoadRocketAudioClip" + resPath, gameObject);
    }

    protected override void Start()
    {
        int CurrenScene = SceneManager.GetActiveScene().buildIndex;
        
        if (CurrenScene == 0) 
            PlayMusic(backgroundMenuAudioClip);
        else
            PlayMusic(backgroundMapAudioClip);

        if(PlayerPrefs.HasKey("music"))
            musicAudioSource.volume = PlayerPrefs.GetFloat("music");

        if(PlayerPrefs.HasKey("sfx"))
            sfxAudioSource.volume = PlayerPrefs.GetFloat("sfx");

        allAudioSources = new AudioSource[]
        {
            musicAudioSource,
            sfxAudioSource
        };
    }

    public void PlayMusic(AudioClip audioClip)
    {
        musicAudioSource.clip = audioClip;
        musicAudioSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxAudioSource.clip = clip;
        sfxAudioSource.PlayOneShot(clip);
    }

    public void PauseAllAudioSources()
    {
        foreach (AudioSource audio in allAudioSources)
            audio.Pause();
    }
    public void UnPauseAllAudioSources()
    {
        foreach (AudioSource audio in allAudioSources)
            audio.UnPause();
    }
}