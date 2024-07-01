using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMapLevel : NguyenMonoBehaviour
{
    [SerializeField] protected GameCtrl gameCtrl;

    [SerializeField] protected int mapLevel = 1;
    public int GetMapLevel => mapLevel;
    [SerializeField] protected int limitMapLevel = 5;
    [SerializeField] protected float timeNextLevel;

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

    protected override void Awake()
    {
        base.Awake();
        this.timeNextLevel = gameCtrl.GetTimeFinish / this.limitMapLevel;
    }


    private void FixedUpdate()
    {
        this.SetMapLevel();
    }

    protected virtual void SetMapLevel()
    {
        if (gameCtrl.GetTime >= timeNextLevel * (this.mapLevel+1) && this.mapLevel < this.limitMapLevel)
            this.mapLevel++;
    }
}
