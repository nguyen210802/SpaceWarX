using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpawnerRandom : SpawnerRandom
{
    private static JunkSpawnerRandom instance;
    public static JunkSpawnerRandom Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        JunkSpawnerRandom.instance = this;
    }
}
