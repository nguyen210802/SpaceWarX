using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDShield : TextTimeCD
{
    protected override void SetTimeDelaySkill()
    {
        this.timeDelaySkill = (int)SkillShield.Instance.GetTimeDelaySkill;
    }
}
