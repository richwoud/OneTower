using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI _textHealth, _textShield, _textReload, _textSpeedBullet;
    private int _towerHealth, _towerShield;
    private float _reloadDelay, _speedBullet;

    private void Start()
    {
        _towerHealth = PlayerPrefs.GetInt("TowerHealth");
        _towerShield = PlayerPrefs.GetInt("TowerShield");
        _reloadDelay = PlayerPrefs.GetFloat("ReloadDelay");
        _speedBullet = PlayerPrefs.GetFloat("SpeedBullet");

        _textHealth.text = $"Tower health: {_towerHealth}";
        _textShield.text = $"Tower shield: {_towerShield}";
        _textReload.text = $"Reload time: {_reloadDelay}";
        _textSpeedBullet.text = $"Speed bullet: {_speedBullet}";
    }

    public void Btn_Exit()
    {
        SceneManager.LoadScene(0);
    }

}
