using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TextTimeCD : BaseText
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
        this.SetTimeDelaySkill();
        if (this.timeDelaySkill <= 0)
            this.text.SetText("");
        else
            this.text.SetText(timeDelaySkill.ToString());
    }

    protected abstract void SetTimeDelaySkill();
}
