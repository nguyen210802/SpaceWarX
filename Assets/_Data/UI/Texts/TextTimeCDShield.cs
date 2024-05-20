using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTimeCDShield : TextTimeCD
{
    protected override void UpdateTimeDelay()
    {
        this.timeDelaySkill = (int)SkillShield.Instance.GetTimeDelaySkill;
        base.UpdateTimeDelay();
    }
}
