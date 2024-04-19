using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : NguyenMonoBehaviour
{
    private static GameCtrl instance;
    public static GameCtrl Instance => instance;

    [SerializeField] protected Camera mainCamera;
    public Camera GetMainCamera => mainCamera;

    protected override void Awake()
    {
        base.Awake();
        if (GameCtrl.instance != null) 
            Debug.LogError("Only 1 GameManager alow to");
        GameCtrl.instance = this;
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
