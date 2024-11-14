using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject explotion;
    GameObject lastExplotion;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            lastExplotion = Instantiate(explotion, transform.position, transform.rotation);
            Destroy(gameObject);
            return;
        }

    }



}
