using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : NguyenMonoBehaviour
{
    [SerializeField] protected TMP_Dropdown fpsDropdown; 
    [SerializeField] protected int targetFPS;

    protected override void Awake()
    {
        this.SetFPS(0);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFPSDropdown();
    }

    protected virtual void LoadFPSDropdown()
    {
        if (this.fpsDropdown != null) return;
        this.fpsDropdown = transform.GetComponent<TMP_Dropdown>();
        Debug.Log(transform.name + ": LoadFPSDropdown", gameObject);
    }

    protected override void Start()
    {
        fpsDropdown.onValueChanged.AddListener(OnDropdownValueChanged);
    }

    protected virtual void OnDropdownValueChanged(int index)
    {
        this.SetFPS(index);
    }

    protected virtual void SetFPS(int index)
    {
        targetFPS = int.Parse(fpsDropdown.options[index].text.ToString());
        Application.targetFrameRate = targetFPS;
    }
}
