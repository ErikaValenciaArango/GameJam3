using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjects : MonoBehaviour
{
    private float topBound = 80;
    private float lowerBound = -30;
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
