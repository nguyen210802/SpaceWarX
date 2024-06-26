using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxSlider : VolumnSlider
{
    protected override void LoadAudioSource()
    {
        GameObject sfx = GameObject.Find("Sfx");
        this.audioSource = sfx.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadSfxAudioSource", gameObject);
    }

    protected override void SetVolumnName()
    {
        this.volumnName = "sfx";
    }
}
