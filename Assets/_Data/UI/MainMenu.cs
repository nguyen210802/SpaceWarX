using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private static MainMenu instance;
    public static MainMenu Instance => instance;

    private void Awake()
    {
        if (MainMenu.instance != null)
            Debug.LogError("Only one MainMenu allow to exit!");
        MainMenu.instance = this;
    }
    public void PauseTime()
    {
        Time.timeScale = 0f;
    }

    public void StopPauseTime()
    {
        Time.timeScale = 1f;
    }
}
