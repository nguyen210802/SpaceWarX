using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasCtrl : NguyenMonoBehaviour
{
    [SerializeField] protected GameObject menu;
    [SerializeField] protected GameObject option;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMenu();
        this.LoadOption();
    }

    protected virtual void LoadMenu()
    {
        if (this.menu != null) return;
        this.menu = transform.Find("Menu").gameObject;
        Debug.Log(transform.name + ": LoadMenu", gameObject);
    }

    protected virtual void LoadOption()
    {
        if (this.option != null) return;
        this.option = transform.Find("Option").gameObject;
        Debug.Log(transform.name + ": LoadOption", gameObject);
    }

    protected override void Start()
    {
        base.Start();
        menu.SetActive(true);
        option.SetActive(false);
    }
}
