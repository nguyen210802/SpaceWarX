using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDInvisible : TextTimeCD
{
    protected override void UpdateTimeDelay()
    {
        this.timeDelaySkill = (int)Invisible.Instance.GetTimeDelaySkill;
        base.UpdateTimeDelay();
    }
}
