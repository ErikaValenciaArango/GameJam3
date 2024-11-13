using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 30.0f;

    // Rango en el eje X
    private float xRange = 36.0f;
    private float xRangen = -21.0f;

    // Rango en el eje Z
    private float zRange = 8.0f;
    private float zRangen = -26.0f;

    public GameObject projectilePrefab;
    public AudioClip launchClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento en el eje X
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed, Space.World);

        // Movimiento en el eje Z
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed, Space.World);

        // Disparo de proyectiles
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            AudioManager.Instance.PlaySFX(launchClip);
        }

        // Limitar el movimiento en el eje X
        if (transform.position.x < xRangen)
        {
            transform.position = new Vector3(xRangen, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Limitar el movimiento en el eje Z
        if (transform.position.z < zRangen)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangen);
        }
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
}

