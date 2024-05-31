using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDInvisible : TextTimeCD
{
    protected override void SetTimeDelaySkill()
    {
        this.timeDelaySkill = (int)Invisible.Instance.GetTimeDelaySkill;
    }
}
