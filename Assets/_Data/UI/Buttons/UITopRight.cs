using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UITopRight : NguyenMonoBehaviour
{
    [SerializeField] protected Button btnExit;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnExit();
    }
    protected virtual void LoadBtnExit()
    {
        if (this.btnExit != null) return;
        this.btnExit = transform.GetComponentInChildren<Button>();
        Debug.Log(transform.name + ": LoadBtnExit", gameObject);
    }
}
