using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    private int _currentEnemyIndex; // ������ �������� �����
    [SerializeField] private int _currentWaveIndex; // ����� �����
    public int CurrentWaveIndex { get => _currentWaveIndex; }

   [SerializeField] private int _enemiesLeftToSpawn; // ����� ������, ������� ����� ���������� � ���� �����

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentWaveIndex", CurrentWaveIndex);

        _enemiesLeftToSpawn = _waves[0].WaveSettings.Length;
        LaunchWave();
    }
    private void Update()
    {
        PlayerPrefs.SetInt("CurrentWaveIndex", CurrentWaveIndex);

    }
    private IEnumerator SpawnEnemyInWave()
    {
        if (_enemiesLeftToSpawn > 0)
        {
            yield return new WaitForSeconds(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].SpawnDelay);

            Instantiate(_waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex].Enemy,
                _waves[_currentWaveIndex].WaveSettings[_currentEnemyIndex]
                .NeededSpawner.transform.position, Quaternion.identity);

            _enemiesLeftToSpawn--;
            _currentEnemyIndex++;
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < _waves.Length - 1 )
            {
                _currentWaveIndex++;
                _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Length;
                _currentEnemyIndex = 0;
            }
        }
    }
    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());

    }
  
}
[System.Serializable]

public class Waves
{
    [SerializeField] private WaveSettings[] _waveSettings;
    public WaveSettings[] WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject _enemy;
    public GameObject Enemy { get =>  _enemy; }
    [SerializeField] private GameObject _neededSpawner;
    public GameObject NeededSpawner { get => _neededSpawner; }
    [SerializeField] private float _spawnDelay;
    public float SpawnDelay { get => _spawnDelay; }
}