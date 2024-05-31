using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDLaser : TextTimeCD
{
    protected override void SetTimeDelaySkill()
    {
        this.timeDelaySkill = (int)SkillLaser.Instance.GetTimeDelaySkill;
    }
}
