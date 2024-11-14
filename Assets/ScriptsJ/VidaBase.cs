using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour
{
    [SerializeField] int vidaBase;

    void Start()
    {
        
    }


    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            vidaBase -= 50;

            if (vidaBase <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("BulletBoss"))
        {
            vidaBase -= 2;

            if (vidaBase <= 0)
            {
                Destroy(gameObject);
            }

            Destroy(collision.gameObject);
        }
    }
}
