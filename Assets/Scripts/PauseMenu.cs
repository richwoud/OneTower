using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool _gameIsPaused = false;

    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _pauseButton;


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
        _player.SetActive(true);
        _pauseButton.SetActive(true);
        Time.timeScale = 1f;
        _gameIsPaused = false;
    }
   
    void Pause()
    {
        _pauseMenuUI.SetActive(true);
        _player.SetActive(false);
        _pauseButton.SetActive(false);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
        _gameIsPaused = false;
        Time.timeScale = 1f;
    }

}
