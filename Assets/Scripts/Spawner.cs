using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    public Transform[] spawnPoint;


    [SerializeField] private Waves[] _waves;
    private int _currentEnemyIndex; // индекс текущего врага
    [SerializeField] private int _currentWaveIndex; // номер волны
    public int CurrentWaveIndex { get => _currentWaveIndex; }

    [SerializeField] private int _enemiesLeftToSpawn; // число врагов, которых нужно заспавнить в этой волне


    private int rand;
    private int randPosition;
    //private float startTimeBtwSpawns;
    private float timeBtwSpawns;
    // Start is called before the first frame update
    void Start()
    {
        timeBtwSpawns = Random.Range(0, 4);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            rand = Random.Range(0, enemy.Length); 
            // if(score == 5000 усложение врагов идет)

            randPosition = Random.Range(0, spawnPoint.Length);
            Instantiate(enemy[rand], spawnPoint[randPosition].transform.position, Quaternion.identity);
            timeBtwSpawns = Random.Range(0, 4);
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}

