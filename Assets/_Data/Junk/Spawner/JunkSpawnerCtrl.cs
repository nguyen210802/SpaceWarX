using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected JunkSpawner junkSpawner;
    public JunkSpawner JunkSpawner => junkSpawner;

    [SerializeField] protected SpawnPoints spawnPoints;
    public SpawnPoints JunkSpawnPoints => spawnPoints;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkSpawner();
        this.LoadSpawnPoints();
    }

    protected virtual void LoadJunkSpawner()
    {
        if (this.junkSpawner != null) return;
        this.junkSpawner = GetComponent<JunkSpawner>();
        Debug.Log(transform.name + ": Load JunkSpawner", gameObject);
    }

    protected virtual void LoadSpawnPoints()
    {
        if(this.spawnPoints != null) return;
        this.spawnPoints = Transform.FindObjectOfType<SpawnPoints>();
        Debug.Log(transform.name + ": Load SpawnPoints", gameObject);
    }
}
