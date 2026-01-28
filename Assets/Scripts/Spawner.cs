using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] pathA; 
    public Transform[] pathB;

    public float timeBetweenWaves = 2f;

    void Start()
    {
        StartCoroutine(SpawnRoutine());
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenWaves);
        }
    }

    void SpawnEnemy()
    {
        int randomChoice = Random.Range(0, 2); 
        
        Transform[] chosenPath;

        if (randomChoice == 0)
        {
            chosenPath = pathA;
        }
        else
        {
            chosenPath = pathB;
        }

        GameObject newEnemy = Instantiate(enemyPrefab, chosenPath[0].position, Quaternion.identity);

        EnemyMovement movement = newEnemy.GetComponent<EnemyMovement>();
        movement.waypoints = chosenPath;
    }
}