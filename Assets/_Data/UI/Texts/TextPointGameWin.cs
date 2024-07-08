using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TextPointGameWin : BaseText
{
    protected override void OnEnable()
    {
        base.OnEnable();
        this.SetText();
    }

    protected virtual void SetText()
    {
        this.text.color = Color.red;
        this.text.SetText("Point: " + TextPoint.Instance.GetPoint.ToString());
    }
}
