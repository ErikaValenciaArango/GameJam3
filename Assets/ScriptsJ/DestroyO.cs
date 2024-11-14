using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float topBound = 85;
    private float lowerBound = -80;
    void Start()
    {

    }


    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {

            Destroy(gameObject);
        }
    }
}
