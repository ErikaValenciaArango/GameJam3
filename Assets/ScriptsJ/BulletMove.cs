using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 40.0f;
    void Start()
    {

    }


    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
