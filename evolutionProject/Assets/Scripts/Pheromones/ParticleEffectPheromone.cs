using UnityEngine;

public class ParticleEffectPheromone : MonoBehaviour
{
    public PheromoneType pheromoneType;
    public float lifespan = 5.0f; // Set the lifespan duration in seconds

    private ParticleSystem particleSystem;
    private ParticleSystem.MainModule mainModule;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        mainModule = particleSystem.main;

        // Automatically destroy the GameObject after 'lifespan' seconds
        Destroy(gameObject, lifespan);
    }

    public void SetIntensity(float intensity)
    {
        // Reduce the blue component of the color based on intensity
        Color startColor = mainModule.startColor.color;
        Color newColor = new Color(startColor.r, startColor.g, startColor.b - intensity, startColor.a);
        mainModule.startColor = new ParticleSystem.MinMaxGradient(newColor);

        // Set the size of the particles based on intensity
        float newSize = Mathf.Lerp(0.1f, 0.5f, intensity);
        mainModule.startSize = newSize;
    }
}
