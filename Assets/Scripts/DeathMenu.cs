using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public static bool _gameIsPaused;

    [SerializeField] private GameObject _deathMenuUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _player;
    [SerializeField] private TowerSettings _towerSettings;
    

   
    private void Start()
    {
        _towerSettings = GameObject.Find("Player").GetComponent<TowerSettings>();
        Pause();
        PlayerPrefs.Save();
        _pauseButton.SetActive(false);
    }

    public void Pause()
    {
        _player.SetActive(false);
        _deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        _gameIsPaused = true;
    }


    public void ContinueButton()
    {
        //место для рекламы
        _pauseButton.SetActive(true);
        _player.SetActive(true);
        _towerSettings.CurrentTowerHealth += _towerSettings.MaxHealthTower;
         _towerSettings._healthBarImage.fillAmount = _towerSettings.MaxHealthTower;
         _deathMenuUI.SetActive(false);
         Time.timeScale = 1f;


    }

    public void ExitMenu()
    {
        _player.SetActive(true);
        SceneManager.LoadScene(2);
        _gameIsPaused = false;
        Time.timeScale = 1f;

    }

}
