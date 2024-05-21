using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int currentScene = activeScene.buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    public void NextLevel()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        int currentScene = activeScene.buildIndex;

        int totalScene = SceneManager.sceneCountInBuildSettings;

        Debug.Log("currentScene: " + currentScene);
        Debug.Log("TotalScene: " + totalScene);

        if (currentScene < totalScene - 1)
            SceneManager.LoadScene(currentScene + 1);
        else
            Debug.Log("Does not exit scene " + (currentScene + 1));
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
