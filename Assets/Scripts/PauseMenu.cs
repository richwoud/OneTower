using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool _gameIsPaused = false;

    [SerializeField] private GameObject _pauseMenuUI;

    public void Pause_Button()
    {
        if (_gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Resume()
    {
        _pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }
   
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }
    public void SettingsMenu()
    {
        Debug.Log("Settings!!!");
    }
    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
        _gameIsPaused = false;
        Time.timeScale = 1f;
    }

}
