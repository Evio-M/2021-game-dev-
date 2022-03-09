using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{

    public float min_X = -9f, max_X = 9f;
    public GameObject[] asteroidPrefab;
    public GameObject enemyPrefab;

    public float timer = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemy", timer);
    }

    void SpawnEnemy()
	{
        float pos_X = Random.Range(min_X, max_X);
        Vector3 temp = transform.position;
        temp.x = pos_X;

        if(Random.Range(0, 2) > 0)
		{
            Instantiate(asteroidPrefab[Random.Range(0, asteroidPrefab.Length)],
                temp, Quaternion.identity);
		}
		else
		{
            Instantiate(enemyPrefab, temp, Quaternion.Euler(0f, 0f, 1800f));
		}

        Invoke("SpawnEnemy", timer);
	}
}
