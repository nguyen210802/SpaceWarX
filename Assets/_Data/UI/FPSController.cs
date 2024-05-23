using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : NguyenMonoBehaviour
{
    [SerializeField] protected TMP_Dropdown fpsDropdown; 
    [SerializeField] protected int targetFPS;

    protected override void OnEnable()
    {
        targetFPS = PlayerPrefs.GetInt("SelectedFPS", 0); 
        fpsDropdown.value = PlayerPrefs.GetInt("SelectedDropdownIndex", 0); 
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
        this.SetFPSByIndex(index);
    }

    protected virtual void SetFPSByIndex(int index)
    {
        targetFPS = int.Parse(fpsDropdown.options[index].text.ToString());
        PlayerPrefs.SetInt("SelectedDropdownIndex", index);
        this.SetFPSByValue(targetFPS);
    }

    protected virtual void SetFPSByValue(int targetFPS)
    {
        Application.targetFrameRate = targetFPS;
        PlayerPrefs.SetInt("SelectedFPS", targetFPS);
    }
}
