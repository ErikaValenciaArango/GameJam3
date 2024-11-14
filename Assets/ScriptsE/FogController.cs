using UnityEngine;

public class FogController : MonoBehaviour
{
    // Esta propiedad permitir� animar la densidad de la niebla desde el Timeline
    [Range(0f, 1f)]
    public float fogDensity = 0.05f;

    void Update()
    {
        // Actualiza la densidad de la niebla en tiempo real
        RenderSettings.fogDensity = fogDensity;
    }
}

