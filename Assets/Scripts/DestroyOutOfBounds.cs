using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float limitZ = 30.0f;
    private float lowerLimitZ = -37.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > limitZ)
        {
            Destroy(gameObject);
        }else if (transform.position.z < lowerLimitZ)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
