using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Vector2 maxposition;
    public Vector2 minposition;
    public GameObject[] enemyPrefabs;
    public float delay = 2;
    public float decreaseDuration = 0.01f;

    float delayLimit = 1;
    Vector2 targetPos;
    float timer;

    private void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (delay > delayLimit)
        {
            delay -= decreaseDuration;
        }

        targetPos.x = Random.Range(minposition.x, maxposition.x);
        targetPos.y = Random.Range(minposition.y, maxposition.y);

        Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)], targetPos, Quaternion.identity);
        timer = delay;
    }

    private void Update()
    {
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
