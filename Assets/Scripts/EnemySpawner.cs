using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [Header("Enemy Type")]
    [SerializeField] private GameObject[] enemies;
    [Space]
    [Header("Wave Params")]
    [SerializeField] private int maxWaves = 5;
    [SerializeField] private float timeBetweenWaves = 15;
    [SerializeField] private int maxEnemiesCount;
    [SerializeField] private float timeToNextEnemy = 1.5f;
    [Space]
    [SerializeField] private GameData gameData;
     
    private int startWaveNumber =0;
    private float currentTime;
     private int enemyOnTheLevel;
    [SerializeField] int sum;

 

    private void Start()
    {
        gameData.waveNumber = startWaveNumber;
        gameData.enemyOnTheLevel = CalculateEnemy();
        currentTime = timeBetweenWaves;
        StartCoroutine(SpawnWave());
    }

    private void Update()
    {
        if(currentTime<=0 && gameData.waveNumber<maxWaves)
        {
            StartCoroutine(SpawnWave());
            currentTime = timeBetweenWaves;
        }

        currentTime-= Time.deltaTime;                    
    }

    private IEnumerator SpawnWave()
    {
        gameData.waveNumber++;
        GameUI.instance.SetInformationPanel();

        for (int i = 0; i < maxEnemiesCount; i++)
        { 
            yield return new WaitForSeconds(timeToNextEnemy);
            CreateNextEnemy();
        }

        maxEnemiesCount+=2;
    }

    private void CreateNextEnemy()
    {
        int enemyIndex = Random.Range(0, enemies.Length);

        GameObject enemy = Instantiate(enemies[enemyIndex], transform.position, transform.rotation);
    }

    private int CalculateEnemy()
    {
        enemyOnTheLevel = maxEnemiesCount;

        for(int i =1; i<=maxWaves;i++)
        {
            sum += enemyOnTheLevel;
            enemyOnTheLevel += 2;
        }
        return sum;
    }
}
