using System;
using UnityEngine;

public class PheromoneController : MonoBehaviour
{
    public PheromoneManager pheromoneManager;
    public PheromoneType followPheromoneType;
    public float range = 100;
    public float maxDistX = 0;
    public float maxDistY = 0;

    public Fish fish;

    private void Awake()
    {
        fish = gameObject.GetComponent<Fish>();
    }

    private void Update()
    {
        // Sense and respond to pheromones  
        
        foreach (Pheromone pheromone in pheromoneManager.activePheromones)
        {
            float maxAttraction = 0;
            if (pheromone.type == followPheromoneType)
            {
                // Adjust AI behavior based on pheromone intensity and distance
                float distanceToPheromone = Vector2.Distance(transform.position, pheromone.position);
                if (distanceToPheromone > range) continue;
                float attraction = pheromone.intensity / distanceToPheromone;
                if (attraction > maxAttraction)
                {
                    maxAttraction = attraction;
                    maxDistX = (transform.position.x - pheromone.position.x)/100;
                    maxDistY = (transform.position.y - pheromone.position.y)/100;
                    
                }

                // Implement behavior based on the attraction to pheromones (e.g., move towards or away)
            }
        }

        // should the fish create pheromones
        if (ShouldEmitPheromone())
        {
            EmitPheromone();
        }

    }

    private bool ShouldEmitPheromone()
    {
        if (fish.energy > 100)
        {
            return true;
        }
        return false;
    }

    private void EmitPheromone()
    {
        pheromoneManager.CreatePheromone(PheromoneType.Food, transform.position, (fish.energy - 80)/20 , 5.0f);
    }
}
