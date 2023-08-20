using UnityEngine;

public enum PheromoneType
{
    Food,
    //Danger,
}

public class Pheromone
{
    public PheromoneType type;
    public Vector2 position;
    public float intensity;
    public float lifespan;
}
