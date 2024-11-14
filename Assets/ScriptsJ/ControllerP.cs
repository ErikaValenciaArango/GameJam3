using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ControllerP : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float limitX;
    [SerializeField] private float limitZ;
    [SerializeField] private float tiempoParaDisparar;
    [SerializeField] private float tiempoActual;
    [SerializeField] private int health;
    [SerializeField] private bool puedeDispararDoble;
    [SerializeField] private bool puedeDispararTriple;
    [SerializeField] private GameObject canonI, canonC, canonD;
    [SerializeField] private float duracionPowerUp;

    private Rigidbody rb;
    private Animator animator;
    public GameObject projectile;
    private bool puedeRecibirDano;

    public GameObject mesh;
    public int numberOfBinks = 5;
    public float blinkDuration = 0.1f;
    


    private void Start()
    {
        puedeDispararDoble = false;
        puedeDispararTriple = false;

        puedeRecibirDano = true;
        health = 3;
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        tiempoActual += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && tiempoActual >= tiempoParaDisparar)
        {
            Shot();
        }

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0 )
        {
            animator.SetInteger("Horizontal", 0);
            rb.velocity = Vector3.zero;
            return;
        }
        float valorZ = Input.GetAxisRaw("Vertical");
        float valorX = Input.GetAxisRaw("Horizontal");
        Vector3 Velocity = new Vector3 (valorX * speed, rb.velocity.y, valorZ * speed );
        rb.velocity = Velocity;
        Vector3 limitedPosition = rb.position;
        limitedPosition.x = Mathf.Clamp(limitedPosition.x , -limitX, limitX);
        limitedPosition.z = Mathf.Clamp(limitedPosition.z , -limitZ, limitZ);
        rb.position = limitedPosition;

        animator.SetInteger("Horizontal", (int)valorX);
        //rb.velocity = new Vector3 (valorX * speed, 0, valorZ * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Boss") && puedeRecibirDano == true)
        {
            RecibirDano();
        }

        if (collision.gameObject.CompareTag("Enemy") && puedeRecibirDano == true)
        {
            Destroy(collision.gameObject);
            RecibirDano();
        }

        if (collision.gameObject.CompareTag("BulletBoss") && puedeRecibirDano == true)
        {
            Destroy(collision.gameObject);
            RecibirDano();
        }
    }
    IEnumerator TiempoParaRecibirDano()
    {
        yield return new WaitForSeconds(1);
        puedeRecibirDano = true;
    }

    private void RecibirDano()
    {
        health -= 1;
        StartCoroutine(EfectoParpadeo());
        puedeRecibirDano = false;
        StartCoroutine(TiempoParaRecibirDano());
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator EfectoParpadeo()
    {
        for (int i = 0; i < numberOfBinks; i++) 
        {
            mesh.SetActive(false); 
            yield return new WaitForSeconds(blinkDuration);
            mesh.SetActive(true);
            yield return new WaitForSeconds(blinkDuration);
        }  
    }

    private void Shot()
    {
        if (puedeDispararDoble == false && puedeDispararTriple == false)
        {
            Instantiate(projectile, canonC.transform.position, projectile.transform.rotation);
            tiempoActual = 0;
        }

        if (puedeDispararTriple)
        {
            Instantiate(projectile, canonI.transform.position, projectile.transform.rotation);
            Instantiate(projectile, canonC.transform.position, projectile.transform.rotation);
            Instantiate(projectile, canonD.transform.position, projectile.transform.rotation);
            tiempoActual = 0;
        }

        if (puedeDispararDoble)
        {
            Instantiate(projectile, canonI.transform.position, projectile.transform.rotation);
            Instantiate(projectile, canonD.transform.position, projectile.transform.rotation);
            tiempoActual = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUp"))
        {
            StopAllCoroutines();
            PowerUps powerUpCollision = other.GetComponent<PowerUps>();
            switch (powerUpCollision.powerUp)
            {
                case PowerUps.TipoPowerUp.speedGun:
                    tiempoParaDisparar = 0.2f;
                    break;

                case PowerUps.TipoPowerUp.doubleGun:
                    puedeDispararDoble = true;
                    puedeDispararTriple = false;
                    break;

                case PowerUps.TipoPowerUp.tripleGun:
                    puedeDispararTriple = true;
                    puedeDispararDoble  = false;
                    break;  
            }

            StartCoroutine(AcabarPowerUp());
            Destroy(other.gameObject);

        }
    }

    IEnumerator AcabarPowerUp()
    {
        yield return new WaitForSeconds (10);
        tiempoParaDisparar = 0.5f;
        puedeDispararDoble = false;
        puedeDispararTriple = false;
    }
}
