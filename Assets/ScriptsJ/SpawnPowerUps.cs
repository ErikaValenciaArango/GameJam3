using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUps : MonoBehaviour
{
    [SerializeField] private float limitX;
    [SerializeField] private float limitZ;
    [SerializeField] private GameObject doubleGun, speedGun, tripleGun;
    [SerializeField] private GameObject objetoCreado;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 40, 40);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int numeroRandom = Random.Range(0, 3);
        float posXRandom = Random.Range(-limitX ,limitX);
        float posZRandom = Random.Range(-limitZ, limitZ);
        Vector3 poscicionAleatoria = new Vector3(posXRandom, 9,posZRandom);
        if (objetoCreado != null)
        {
            Destroy(objetoCreado);
        }

        switch (numeroRandom)
        {
            case 0:
                objetoCreado = Instantiate(speedGun, poscicionAleatoria, Quaternion.identity);
                break;

            case 1:
                objetoCreado = Instantiate(doubleGun, poscicionAleatoria, Quaternion.identity);
                break;

            case 2:
                objetoCreado = Instantiate(tripleGun, poscicionAleatoria, Quaternion.identity);
                break;
        }
    }
}
