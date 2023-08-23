using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public bool mutateMutations = true;
    public GameObject agentPrefab;
    public bool isUser = false;
    public bool canEat = true;
    public float viewDistance = 20;
    public float size = 1.0f;
    public float energy = 20;
    public float energyGained = 10;
    public float reproductionEnergyGained = 1;
    public float reproductionEnergy = 0;
    public float reproductionEnergyThreshold = 10;
    //public float timeUntilReproduce = 50;
    public float FB = 0;
    public float LR = 0;
    public int numberOfChildren = 1;
    private bool isMutated = false;
    float elapsed = 0f;
    public float lifeSpan = 0f;
    public float[] distances = new float[20];

    public float mutationAmount = 0.8f;
    public float mutationChance = 0.2f;
    public FishNN nn;
    public FishMovement movement;

    float relativeFoodX;
    float relativeFoodY;

    private List<GameObject> edibleFoodList = new List<GameObject>();

    public bool isDead = false;


    public float fadeDuration = 0.0f; // Duration in seconds for fading
    private Renderer renderer;
    private Color startColor;

    public int numRaycasts = 18;
    public float angleBetweenRaycasts = 10;

    public PheromoneController pheromoneController;
    public float maxPheromone = 0;

    public int lives = 1;

    public GameObject raycastVisualizationPrefab;

    private int numRays = 0;

    public Counter counter;
    // Start is called before the first frame update
    void Awake()
    {
        nn = gameObject.GetComponent<FishNN>();
        movement = gameObject.GetComponent<FishMovement>();
        pheromoneController = gameObject.GetComponent<PheromoneController>();
        distances = new float[18];

        

        //this.name = "Agent";

        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //only do this once
        if (!isMutated)
        {
            //call mutate function to mutate the neural network
            MutateCreature();
            this.transform.localScale = new Vector3(size, size, 0); //////////////////
            isMutated = true;
            //energy = 20;
        }

        ManageEnergy();


        RaycastHit2D hit;
        for (int i = 0; i < numRaycasts; i++)
        {
            float angle = ((2 * i + 1 - numRaycasts) * angleBetweenRaycasts / 2);

            //float angle = (i / (float)(numRaycasts - 1) - 0.5f) * angleBetweenRaycasts;
            Quaternion rotation = Quaternion.Euler(0, 0, angle + transform.eulerAngles.z);
            Vector2 rayDirection = rotation * Vector2.up;

            float offset = 0.3f * transform.localScale.y;
            Vector2 rayStart = (Vector2)transform.position + offset * rayDirection;

            //Debug.DrawRay(rayStart, rayDirection * viewDistance, Color.red); // Debug draw the ray

            hit = Physics2D.Raycast(rayStart, rayDirection, viewDistance);
            

            Vector2 endPoint;
            distances[i] = 1;
            //distances[i+6] = 1;

            if (hit.collider != null)
            {
                Vector2 hitPoint = rayStart + rayDirection * hit.distance;
                endPoint = hitPoint;
                Debug.DrawLine(rayStart, hitPoint, Color.red);
                if (hit.transform.gameObject.tag == "Agent")
                {
                    distances[i] = hit.distance / viewDistance;
                }
                else if (hit.transform.gameObject.tag == "FishFoodCollider")
                {
                    distances[i] = -1 * hit.distance / viewDistance;
                }
            }
            else
            {
                endPoint = rayStart + rayDirection * viewDistance;
                Debug.DrawLine(rayStart, endPoint, Color.red);
            }
            
        }

        // get pheromone inputs
        ////float maxDistx = pheromoneController.maxDistX;
        ////float maxDisty = pheromoneController.maxDistY;

        ////distances[numRaycasts] = maxDistx;
        ////distances[numRaycasts + 1] = maxDisty;

        // Setup inputs for the neural network
        float[] inputsToNN = distances;

        // Get outputs from the neural network
        float[] outputsFromNN = nn.Brain(inputsToNN);

        //Store the outputs from the neural network in variables
        FB = outputsFromNN[0];
        LR = outputsFromNN[1];

        //if the agent is the user, use the inputs from the user instead of the neural network
        if (isUser)
        {
            FB = Input.GetAxis("Vertical");
            LR = Input.GetAxis("Horizontal") / 10;
        }

        //Move the agent using the move function
        movement.Move(FB, LR);
    }

    //this function gets called whenever the agent collides with a trigger. (Which in this case is the food)
    void OnCollisionEnter2D(Collision2D col)
    {

        //if the agent collides with a food object, it will eat it and gain energy.
        if (col.gameObject.tag == "FishFood" && canEat)
        {

            energy += energyGained;
            reproductionEnergy += reproductionEnergyGained;
            Destroy(col.gameObject);
             
        }
    }


    //public void ManageEnergy()
    //{
    //    elapsed += Time.deltaTime;
    //    lifeSpan += Time.deltaTime;

    //    if (lifeSpan > timeUntilReproduce)
    //    {
    //        //List[] list = GameObject.FindGameObjectsWithTag("FoodAI");
    //        // if there are no agents in the scene, spawn one at a random location. 
    //        // This is to ensure that there is always at least one agent in the scene.
    //        //if (agentList.Length < 5)
    //        //{
    //        //    SpawnCreature();
    //        //}
    //        int num = Random.Range(1, 10);
    //        if (num < 8) { Reproduce(); }

    //        lifeSpan = 0;
    //    }
    //}

    public void ManageEnergy()
    {
        elapsed += Time.deltaTime;
        lifeSpan += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;

            //subtract 1 energy per second
            energy -= 1f;

            //if agent has enough energy to reproduce, reproduce
            if (reproductionEnergy >= reproductionEnergyThreshold)
            {
                reproductionEnergy = 0;
                if (counter.fish < 100)
                {
                    Reproduce();
                }
            }
        }

        //Starve
        //float agentY = this.transform.position.y;
        if (energy <= 0) // || agentY < -10)
        {
            //this.transform.Rotate(0, 0, 180);
            //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + 3.5f, this.transform.position.z);
            //StartCoroutine(FadeOutAndDestroy());
            //Destroy(this.gameObject, 3);
            //GetComponent<FishMovement>().enabled = false;
            //StartCoroutine(FadeOutAndDestroy());
            Destroy(gameObject);
            
        }

    }

    //private IEnumerator Die()
    //{
    //    // Turn the fish grey
    //    renderer.material.color = Color.grey;

    //    // Stop moving
    //    FishMovement fishMovement = GetComponent<FishMovement>();
    //    fishMovement.enabled = false;

    //    fishMovement.speed = 0;
    //    fishMovement.rotateSpeed = 0;

    //    gameObject.tag = "Food";


    //    // Wait for 4 seconds
    //    //yield return new WaitForSeconds(2f);

    //    // Start fading out and destroy
    //    StartCoroutine(FadeOutAndDestroy());
    //}

    private IEnumerator FadeOutAndDestroy()
    {
        Material material = renderer.material;
        Color startColor = material.color;
        Color transparentColor = new Color(startColor.r, startColor.g, startColor.b, 0);

        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            Color currentColor = Color.Lerp(startColor, transparentColor, normalizedTime);
            material.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Once fading is complete, destroy the creature
        Destroy(gameObject);
        
    }

    private void MutateCreature()
    {
        if (mutateMutations)
        {
            mutationAmount += Random.Range(-1.0f, 1.0f) / 100;
            mutationChance += Random.Range(-1.0f, 1.0f) / 100;
        }

        //make sure mutation amount and chance are positive using max function
        mutationAmount = Mathf.Max(mutationAmount, 0);
        mutationChance = Mathf.Max(mutationChance, 0);

        nn.MutateNetwork(mutationAmount, mutationChance);
    }

    public void Reproduce()
    {
        //replicate
        for (int i = 0; i < numberOfChildren; i++) // I left this here so I could possibly change the number of children a parent has at a time.
        {
            //create a new agent, and set its position to the parent's position + a random offset in the x and z directions (so they don't all spawn on top of each other)
            
            GameObject child = Instantiate(agentPrefab, new Vector3(
                (float)this.transform.position.x + Random.Range(-10, 11),
                (float)this.transform.position.y + Random.Range(-10, 11),
                0.0f),
                Quaternion.identity);

            //child.SetActive = true;
            //copy the parent's neural network to the child
            child.GetComponent<FishNN>().layers = GetComponent<FishNN>().copyLayers();
            child.GetComponent<Fish>().lifeSpan = 0;
            child.GetComponent<Fish>().elapsed = 0;
        }
        //reproductionEnergy = 0;

    }
}

