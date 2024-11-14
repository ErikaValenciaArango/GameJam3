using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject canonIz, canonDe;
    [SerializeField] private int faseActual;
    [SerializeField] private bool puedeCambiarFase;
    [SerializeField] private float tiempoEntreFase;
    [SerializeField] private float tiempoActual;
    [SerializeField] private float health;
    private void Start()
    {
        faseActual = 1;
        tiempoActual = 0;
        health = 1000;
    }

    void Update()
    {
        tiempoActual += Time.deltaTime; 
        if (faseActual == 1 && tiempoActual >= tiempoEntreFase)
        {
            CambioDeFase();
            tiempoActual = 0;
        }
        Vector3 position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

        if (faseActual == 1 )
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }        
    }
    void Shot()
    {
        Instantiate(bulletPrefab, canonIz.transform.position, Quaternion.identity);
        Instantiate(bulletPrefab, canonDe.transform.position, Quaternion.identity);
    }

    private void Embestida()
    {
        transform.DOMoveZ(-5, 1.5f).OnComplete(() =>
        {
            transform.DOMoveZ(75, 0.5f).OnComplete(() =>  
            {
                CambioDeFase();
            });
        });

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Destroy(collision.gameObject);
            health -= 5;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnEnable()
    {
        InvokeRepeating ("Shot", 2, 0.7f);
        tiempoActual = 0;       
    }

    private void CambioDeFase()
    {
        if (faseActual == 1)
        {
            CancelInvoke("Shot");
            faseActual = 2;
            Embestida();
        }
        else
        {
            faseActual = 1;
            InvokeRepeating("Shot", 2, 0.5f);
        }
    }
}
