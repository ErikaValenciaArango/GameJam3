using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    [SerializeField] private float spawnRangeX = 66;
    [SerializeField] private float spawnPosZ = 70;
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", 2, 1);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomEnemy()
    {
        int enemyindex = Random.Range(0, enemyPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 9, spawnPosZ);
        if (GameManager.Instance.bossActivo == false) 
        {
            Instantiate(enemyPrefabs[enemyindex], spawnPos, enemyPrefabs[enemyindex].transform.rotation);
        }
    }
}
