using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : NguyenMonoBehaviour
{
    [Header("Level")]
    [SerializeField] protected int levelCurrent = 0;
    [SerializeField] protected int maxLevel = 99;

    public int GetLevelCurrent => levelCurrent;
    public int GetMaxLevel => maxLevel;

    public virtual void LevelUp()
    {
        this.levelCurrent += 1;
        this.LimitLevel();
    }

    public virtual void LevelSet(int newLevel)
    {
        this.levelCurrent = newLevel;
        this.LimitLevel();
    }

    protected virtual void LimitLevel()
    {
        if(this.levelCurrent > this.maxLevel) this.levelCurrent = this.maxLevel;
        if(this.levelCurrent < 1)   this.levelCurrent = 1;
    }
}
