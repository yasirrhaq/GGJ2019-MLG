using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolSpawner : MonoBehaviour
{
    public GameObject currentEnemy;
    public GameObject[] enemyPrefabs;
    public float delay = 5;

    float timer;
    bool isSpawning;
    
    public void SpawnEnemy()
    {
        currentEnemy = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], transform.position, Quaternion.identity);
        timer = delay;
        isSpawning = false;
    }

    private void Update()
    {
        if (currentEnemy == null)
        {
            if (!isSpawning)
            {
                isSpawning = true;
            }
            if (timer <= 0)
            {
                SpawnEnemy();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }        
    }
}
