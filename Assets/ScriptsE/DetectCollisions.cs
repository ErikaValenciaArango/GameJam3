using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    public ParticleSystem explosionParticle;

    private void OnTriggerEnter(Collider other)
    {
        // Destruir los objetos
        Destroy(gameObject);
        Destroy(other.gameObject);

        // Instanciar el sistema de part�culas en la posici�n actual
        ParticleSystem explosion = Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);

        // Destruir el sistema de part�culas una vez que termine de reproducirse
        Destroy(explosion.gameObject, explosion.main.duration);
    }
}

