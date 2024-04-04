using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NguyenMonoBehaviour : MonoBehaviour
{
    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
        this.OnEnable();
    }

    protected virtual void LoadComponents() { }
    protected virtual void ResetValue() { }
    protected virtual void Start(){}
    protected virtual void OnEnable() { }
    protected virtual void OnDisable() { }
}
