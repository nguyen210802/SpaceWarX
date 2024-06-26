using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class VolumnSlider : NguyenMonoBehaviour
{
    [SerializeField] protected Slider volumnSlider;
    [SerializeField] protected AudioSource audioSource;

    [SerializeField] protected String volumnName;
    // Start is called before the first frame update
    protected override void Start()
    {
        if (!PlayerPrefs.HasKey(volumnName))
        {
            PlayerPrefs.SetFloat(volumnName, 1);
            Load();
        }
        else
            Load();
        volumnSlider.onValueChanged.AddListener(delegate { ChangeVolumn(); });
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadVolumnSlider();
        this.LoadAudioSource();
        this.SetVolumnName();
    }

    protected virtual void LoadVolumnSlider()
    {
        if (this.volumnSlider != null) return;
        this.volumnSlider = transform.GetComponent<Slider>();
        Debug.Log(transform.name + ": LoadVolumnSlider", gameObject);
    }

    protected virtual void ChangeVolumn()
    {
        Save();
        audioSource.volume = PlayerPrefs.GetFloat(volumnName);
    }

    protected virtual void Load()
    {
        volumnSlider.value = PlayerPrefs.GetFloat(volumnName);
        audioSource.volume = PlayerPrefs.GetFloat(volumnName);
    }

    protected virtual void Save()
    {
        PlayerPrefs.SetFloat(volumnName, volumnSlider.value);
    }

    protected abstract void LoadAudioSource();
    protected abstract void SetVolumnName();
}
