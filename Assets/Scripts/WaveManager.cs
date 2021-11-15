using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public List<GameObject> enemyPrefabs = new List<GameObject>();
    public int numEnemiesFirstWave = 5;
    public int numAdditionalEnemiesPerWave = 3;
    public float delayBetweenSpawns = .5f;
    public float delayBetweenWaves = 3;

    private int numEnemiesThisWave;

    // Start is called before the first frame update
    void Start()
    {
        numEnemiesThisWave = numEnemiesFirstWave;
        StartCoroutine(SpawnWave());

        //If you want to stop the coroutine before its finished, 
        //do it like this:
        //Coroutine waveRoutine = StartCoroutine(SpawnWave());
        //StopCoroutine(waveRoutine);
    }

    //Coroutines in Unity
    //Return type must be IEnumerator
    //Should contain a loop
    //The loop should have the 'yield' keyword inside it somewhere
    IEnumerator SpawnWave()
    {
        for(int i = 0; i < numEnemiesThisWave; ++i)
        {
            GameObject prefabToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Count)];
            Instantiate(prefabToSpawn, WaypointManager.staticWaypoints[0], Quaternion.identity);
            yield return new WaitForSeconds(delayBetweenSpawns);

            //This for loop will spawn 1 enemy, then pause and we will return to it
            //in a later frame.
        }

        numEnemiesThisWave += numAdditionalEnemiesPerWave;
        yield return new WaitForSeconds(delayBetweenWaves);
        StartCoroutine(SpawnWave());
    }
}
