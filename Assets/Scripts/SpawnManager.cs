using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private Waves[] _waves;
    //private int _currentEnemyIndex; // индекс текущего врага
    [SerializeField] private int _currentWaveIndex; // номер волны
    public int CurrentWaveIndex { get => _currentWaveIndex; set => _currentWaveIndex = value; }


    int randEnemy;
    int randPos;
    float spawnBtw;

    [SerializeField] private int _enemiesLeftToSpawn; // число врагов, которых нужно заспавнить в этой волне

    private void Start()
    {
        PlayerPrefs.SetInt("CurrentWaveIndex", CurrentWaveIndex );

        _enemiesLeftToSpawn = _waves[0].WaveSettings.Enemy.Length;
        LaunchWave();
    }
    private void Update()
    {
        PlayerPrefs.SetInt("CurrentWaveIndex", CurrentWaveIndex );
       
    }
    private IEnumerator SpawnEnemyInWave()
    {

        if (_enemiesLeftToSpawn > 0)
        {
            spawnBtw = Random.Range(0, 3.5f);
            _waves[_currentWaveIndex].WaveSettings.SpawnDelay = spawnBtw;

            yield return new WaitForSeconds(_waves[_currentWaveIndex].WaveSettings.SpawnDelay);

            randEnemy = Random.Range(0, _waves[_currentWaveIndex].WaveSettings.Enemy.Length);
            randPos = Random.Range(0, _waves[_currentWaveIndex].WaveSettings
                .NeededSpawner.Length);

            Instantiate(_waves[_currentWaveIndex].WaveSettings.Enemy[randEnemy],
                _waves[_currentWaveIndex].WaveSettings.NeededSpawner[randPos].transform.position, Quaternion.identity);

            _enemiesLeftToSpawn--;
            //_currentEnemyIndex++;
            StartCoroutine(SpawnEnemyInWave());
        }
        else
        {
            if (_currentWaveIndex < _waves.Length - 1)
            {
               
                _currentWaveIndex++;
                _enemiesLeftToSpawn = _waves[_currentWaveIndex].WaveSettings.Enemy.Length;
                //if (_currentWaveIndex == 99 && _enemiesLeftToSpawn == 0)
                //{
                //    VictoryGame();s
                //}
                //_currentEnemyIndex = 0;
            }
            
        }
    }
    public void VictoryGame()
    {
        SceneManager.LoadScene(6);
    }

    public void LaunchWave()
    {
        StartCoroutine(SpawnEnemyInWave());

    }

}
[System.Serializable]

public class Waves
{
    [SerializeField] private WaveSettings _waveSettings;
    public WaveSettings WaveSettings { get => _waveSettings; }
}

[System.Serializable]
public class WaveSettings
{
    [SerializeField] private GameObject[] _enemy;
    public GameObject[] Enemy { get => _enemy; }
    [SerializeField] private GameObject[] _neededSpawner;
    public GameObject[] NeededSpawner { get => _neededSpawner; }
    private float _spawnDelay;
    public float SpawnDelay { get => _spawnDelay; set => _spawnDelay = value; }
}