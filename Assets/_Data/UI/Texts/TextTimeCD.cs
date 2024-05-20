using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCD : BaseText
{
    [SerializeField] protected int timeDelaySkill;

    protected override void Start()
    {
        text.color = Color.red;
    }

    protected virtual void FixedUpdate()
    {
        this.UpdateTimeDelay();
    }

    protected virtual void UpdateTimeDelay()
    {
        if (this.timeDelaySkill <= 0)
            this.text.SetText("");
        else
            this.text.SetText(timeDelaySkill.ToString());
    }
}
