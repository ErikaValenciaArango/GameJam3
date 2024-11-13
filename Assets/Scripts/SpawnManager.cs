using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    private float limitX = 35.0f;
    private float limitXn = -20.0f;
    private float limitZ = 20.0f;
    private float startDelay = 2;
    private float spawnAnimal = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnAnimalRandom", startDelay, spawnAnimal);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnAnimalRandom()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 spanPos = new Vector3(Random.Range(limitXn, limitX), 4, limitZ);
        Instantiate(animalPrefab[animalIndex], spanPos, animalPrefab[animalIndex].transform.rotation);
    }
}
