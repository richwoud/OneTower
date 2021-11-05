using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI _textHealth, _textShield, _textReload, _textSpeedBullet, _textDamageBullet;
    private int _towerHealth, _damageBullet;
    private float _reloadDelay, _speedBullet;

    private void Start()
    {
        _towerHealth = PlayerPrefs.GetInt("TowerHealth");
        _reloadDelay = PlayerPrefs.GetFloat("ReloadDelay");
        _speedBullet = PlayerPrefs.GetFloat("SpeedBullet");
        _damageBullet = PlayerPrefs.GetInt("DamageBullet");

        _textHealth.text = _towerHealth.ToString();
        _textReload.text = _reloadDelay.ToString();
        _textSpeedBullet.text =_speedBullet.ToString();
        _textDamageBullet.text = _damageBullet.ToString();
    }

    public void Btn_Exit()
    {
        SceneManager.LoadScene(0);
    }

}
