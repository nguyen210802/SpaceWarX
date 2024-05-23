using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : NguyenMonoBehaviour
{
    private static MapCtrl instance;
    public static MapCtrl Instance => instance;

    [SerializeField] protected float limitX = 25;
    public float GetLimitX => limitX;
    [SerializeField] protected float limitY = 25;
    public float GetLimitY => limitY;

    protected override void Awake()
    {
        if (MapCtrl.instance != null)
            Debug.LogWarning("Only 1 MapCtrl allow to exit");
        MapCtrl.instance = this;
    }
}
