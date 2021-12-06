using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveManager : MonoBehaviour
{
    public GameObject endOfLevelPanel;
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public int numEnemiesFirstWave = 5;
    public int numAdditionalEnemiesPerWave = 3;
    public int totalNumOfWaves = 5;
    public float delayBetweenSpawns = .5f;
    public float delayBetweenWaves = 3;

    private int numEnemiesThisWave;
    private int currentWaveNum = 1;
    private int numOfEnemiesSpawned = 0;
    private bool wavesEnded;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;

        numEnemiesThisWave = numEnemiesFirstWave;
        StartCoroutine(SpawnWave());
        wavesEnded = false;

        //If you want to stop the coroutine before its finished, 
        //do it like this:
        //Coroutine waveRoutine = StartCoroutine(SpawnWave());
        //StopCoroutine(waveRoutine);
    }

    void FixedUpdate()
    {
        if (wavesEnded && numOfEnemiesSpawned == Enemy.numOfEnemiesDestroyed)
        {
            //SceneManager.LoadScene("Level2");
            endOfLevelPanel.SetActive(true);
        }
    }

    //Coroutines in Unity
    //Return type must be IEnumerator
    //Should contain a loop
    //The loop should have the 'yield' keyword inside it somewhere
    IEnumerator SpawnWave()
    {
        for (int i = 0; i < numEnemiesThisWave; ++i)
        {
            GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(prefabToSpawn, WaypointManager.staticWaypoints[0], Quaternion.identity);
            numOfEnemiesSpawned++;
            yield return new WaitForSeconds(delayBetweenSpawns);

           //This for loop will spawn 1 enemy, then pause and we will return to it
           //in a later frame.
        }

        numEnemiesThisWave += numAdditionalEnemiesPerWave;
        yield return new WaitForSeconds(delayBetweenWaves);

        if (currentWaveNum < totalNumOfWaves)
        {
            currentWaveNum++;
            StartCoroutine(SpawnWave());
        }
        else
        {
            StopCoroutine(SpawnWave());
            wavesEnded = true;
        } 
    }

    
}
