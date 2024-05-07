using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCtrl : MonoBehaviour
{
    private static MapCtrl instance;
    public static MapCtrl Instance => instance;

    [SerializeField] protected float limitX = 50;
    public float GetLimitX => limitX;
    [SerializeField] protected float limitY = 50;
    public float GetLimitY => limitY;
}
