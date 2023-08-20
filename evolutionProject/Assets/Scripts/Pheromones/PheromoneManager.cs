using System.Collections.Generic;
using UnityEngine;

public class PheromoneManager : MonoBehaviour
{
    public GameObject pheromonePrefab;
    public List<Pheromone> activePheromones = new List<Pheromone>();

    public void CreatePheromone(PheromoneType type, Vector2 position, float intensity, float lifespan)
    {
        Pheromone pheromone = new Pheromone
        {
            type = type,
            position = position,
            intensity = intensity,
            lifespan = lifespan
        };
        activePheromones.Add(pheromone);

        // Instantiate visual representation (e.g., particle effect) of pheromone
        GameObject pheromoneObject = Instantiate(pheromonePrefab, position, Quaternion.identity);

        // Activate the pheromone prefab
        pheromoneObject.SetActive(true);
    }

    void Update()
    {
        // Update and decay pheromones over time
        for (int i = activePheromones.Count - 1; i >= 0; i--)
        {
            Pheromone pheromone = activePheromones[i];
            pheromone.lifespan -= Time.deltaTime;

            if (pheromone.lifespan <= 0)
            {
                activePheromones.RemoveAt(i);
            }
        }
    }
}
