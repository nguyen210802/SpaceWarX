using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSlider : VolumnSlider
{
    protected override void LoadAudioSource()
    {
        GameObject music = GameObject.Find("Music");
        this.audioSource = music.GetComponent<AudioSource>();
        Debug.Log(transform.name + ": LoadMusicAudioSource", gameObject);
    }

    protected override void SetVolumnName()
    {
        this.volumnName = "music";
    }
}
