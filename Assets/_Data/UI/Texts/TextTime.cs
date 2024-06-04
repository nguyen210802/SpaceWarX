using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class TextTime : BaseText
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SetText());
    }

    //private void FixedUpdate()
    //{
    //    this.SetTime();
    //}

    IEnumerator SetText()
    {
        while (true)
        {
            this.SetTime();
            yield return new WaitForSeconds(1f);
        }
    }

    protected virtual void SetTime()
    {
        float time = GameCtrl.Instance.GetTime;
        float timeFinish = GameCtrl.Instance.GetTimeFinish;

        int minutes = (int) time / 60;
        int seconds = (int) time - minutes * 60;

        float persent = time / timeFinish * 100;
        if (persent >= 100f) persent = 100;

        //this.text.SetText(minutes + " : " + seconds + "\n" +
        //    persent.ToString("F2") + "%");
        this.text.SetText( (minutes / 10 > 0 ? $"{minutes}:" : $"0{minutes}" ) + " : "
                           + (seconds / 10 > 0 ? $"{seconds}" : $"0{seconds}") + "\n" 
                            + persent.ToString("F2") + "%");

    }
}
