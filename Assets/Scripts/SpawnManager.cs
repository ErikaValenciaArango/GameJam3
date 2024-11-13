using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    private float limitX = 35.0f;
    private float limitXn = -20.0f;
    private float limitZ = 20.0f;
    private float startDelay = 2;
    private float spawnEnemy = 3f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemyRandom", startDelay, spawnEnemy);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnEnemyRandom()
    {
        int enemyIndex = Random.Range(0, enemyPrefab.Length);
        Vector3 spanPos = new Vector3(Random.Range(limitXn, limitX), 4, limitZ);
        Instantiate(enemyPrefab[enemyIndex], spanPos, enemyPrefab[enemyIndex].transform.rotation);
    }
}
