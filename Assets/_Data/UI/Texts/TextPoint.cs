using System.Buffers.Text;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPoint : BaseText
{
    private static TextPoint instance;
    public static TextPoint Instance => instance;

    [SerializeField] protected int point = 0;
    public int GetPoint => point;

    protected override void Awake()
    {
        base.Awake();
        if (TextPoint.instance != null)
            Debug.LogError("Only one TextPoint allow to exit!");
        TextPoint.instance = this;
    }

    public virtual void AddPoint(int value)
    {
        this.point += value;
        this.text.SetText(this.point.ToString());
    }
}
