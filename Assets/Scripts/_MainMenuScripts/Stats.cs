using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{
    public TextMeshProUGUI _textHealth, _textShield, _textReload;
    private int _towerHealth, _towerShield;
    private float _reloadDelay;

    private void Start()
    {
        _towerHealth = PlayerPrefs.GetInt("TowerHealth");
        _towerShield = PlayerPrefs.GetInt("TowerShield");
        _reloadDelay = PlayerPrefs.GetFloat("ReloadDelay");

        _textHealth.text = $"Tower health: {_towerHealth}";
        _textShield.text = $"Tower shield: {_towerShield}";
        _textReload.text = $"Reload time: {_reloadDelay}";

    }

    public void Btn_Exit()
    {
        SceneManager.LoadScene(0);
    }

}
