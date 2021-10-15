using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool _gameIsPaused;

    [SerializeField] private GameObject _deathMenuUI;
    [SerializeField] private GameObject _pauseButton;


    private void Start()
    {
        Pause();
        PlayerPrefs.Save();
        _pauseButton.SetActive(false);
    }

    public void Pause()
    {
        _deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }


    public void ContinueButton()
    {
        _deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(2);
        _gameIsPaused = false;
        Time.timeScale = 1f;

    }

}
