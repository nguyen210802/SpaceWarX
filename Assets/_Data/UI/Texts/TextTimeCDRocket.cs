using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDRocket : TextTimeCD
{
    protected override void SetTimeDelaySkill()
    {
        this.timeDelaySkill = (int)SkillRocket.Instance.GetTimeDelaySkill;
    }
}
