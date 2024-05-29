using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Bar : NguyenMonoBehaviour
{
    public Image fillBar;
    [SerializeField] protected float currentValue;
    [SerializeField] protected float maxValue;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFillBar();
    }

    protected virtual void LoadFillBar()
    {
        if (fillBar != null) return;

        Transform fillObj = transform.Find("FillBar");

        this.fillBar = fillObj.GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFillBar", gameObject);
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateBar();
    }

    protected virtual void UpdateBar()
    {
        this.SetValue();
        fillBar.fillAmount = currentValue / maxValue;
    }

    protected abstract void SetValue();
}
