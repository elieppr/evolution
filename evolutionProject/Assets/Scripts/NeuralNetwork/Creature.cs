using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    public bool mutateMutations = true;
    public GameObject agentPrefab;
    public bool isUser = false;
    public bool canEat = true;
    public float viewDistance = 20;
    public float size;
    public float maxSize;
    public float minSize;
    public float maxEnergy = 500;
    public float energy = 20;
    public float energyGained = 10;
    public float reproductionEnergyGained = 1;
    public float reproductionEnergy = 0;
    public float reproductionEnergyThreshold = 10;
    public float FB = 0;
    public float LR = 0;
    public int numberOfChildren = 5;
    private bool isMutated = false;
    float elapsed = 0f;
    public float lifeSpan = 0f;
    public float maxLifeSpan = 700;
    public float[] distances = new float[6];
    public bool isColored;

    public float mutationAmount = 0.8f;
    public float mutationChance = 0.2f;
    public NN nn;
    public Movement movement;

    float relativeFoodX;
    float relativeFoodY;

    private List<GameObject> edibleFoodList = new List<GameObject>();

    public bool isDead = false;


    public float fadeDuration = 1.5f; // Duration in seconds for fading
    private Renderer renderer;
    private Color startColor;

    public int numRaycasts = 10;
    public float angleBetweenRaycasts = 36;

    public GameObject raycastVisualizationPrefab;

    public Fish fish;

    public Counter counter;

    private int numRays = 0;

    public int totalOffspring = 0;

    private Color originalColor;
    // Start is called before the first frame update
    void Awake()
    {
        nn = gameObject.GetComponent<NN>();
        movement = gameObject.GetComponent<Movement>();
        distances = new float[10];
        
        //fish = gameObject.GetComponent<Fish>();
        //this.name = "Agent";

        renderer = GetComponent<SpriteRenderer>();
        startColor = renderer.material.color;

        size = minSize;

        originalColor = renderer.material.color;
        totalOffspring = 0;
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
        List<float> hitDistances = new List<float>();
        //LayerMask obstacleLayerMask = LayerMask.GetMask("Default", "Penguin", "FishFood"); // Add layers as needed
        LayerMask obstacleLayerMask = LayerMask.GetMask("Fish", "Chunk");
        for (int i = 0; i < numRaycasts; i++)
        {
            float angle = ((2 * i + 1 - numRaycasts) * angleBetweenRaycasts / 2);

            //float angle = (i / (float)(numRaycasts - 1) - 0.5f) * angleBetweenRaycasts;
            Quaternion rotation = Quaternion.Euler(0, 0, angle + transform.eulerAngles.z);
            Vector2 rayDirection = rotation * Vector2.up;

            float offset = 0.1f * transform.localScale.y;
            Vector2 rayStart = (Vector2)transform.position + offset * rayDirection;

            //Debug.DrawRay(rayStart, rayDirection * viewDistance, Color.red); // Debug draw the ray

            //hit = Physics2D.Raycast(rayStart, rayDirection, viewDistance);
            hit = Physics2D.Raycast(rayStart, rayDirection, viewDistance, obstacleLayerMask);
            //GameObject raycastVisualization;
            //LineRenderer lineRenderer = raycastVisualizationPrefab.GetComponent<LineRenderer>();
            //if (numRays < numRaycasts)
            //{
            //    raycastVisualization = Instantiate(raycastVisualizationPrefab, rayStart, Quaternion.identity);
            //    //lineRenderer = raycastVisualization.GetComponent<LineRenderer>();
            //    numRays++;
            //}


            Vector2 endPoint;

            if (hit.collider != null)
            {
                Vector2 hitPoint = rayStart + rayDirection * hit.distance;
                endPoint = hitPoint;
                Debug.DrawLine(rayStart, hitPoint, Color.red);
                if (hit.transform.gameObject.CompareTag("FoodAI") || hit.transform.gameObject.CompareTag("Food"))
                {
                    distances[i] = hit.distance / viewDistance;
                }
                else if (hit.transform.gameObject.CompareTag("Chunk"))
                {
                    Debug.Log("HHHHHHHHHHHHHHHit WALL");
                    distances[i] = -1 * hit.distance / viewDistance;
                }
                else
                {
                    distances[i] = 1;
                }
            }
            else
            {
                endPoint = rayStart + rayDirection * viewDistance;
                Debug.DrawLine(rayStart, endPoint, Color.red);
                distances[i] = 1;
            }
            // Instantiate raycast visualization GameObject
            //GameObject raycastVisualization = Instantiate(raycastVisualizationPrefab, rayStart, Quaternion.identity);
            //LineRenderer lineRenderer = raycastVisualization.GetComponent<LineRenderer>();
            //lineRenderer.SetPosition(0, rayStart);
            //lineRenderer.SetPosition(1, endPoint); // or viewDistance for no hit
            
            
        }


        // Setup inputs for the neural network
        float[] inputsToNN = distances;

        
        // Get outputs from the neural network
        float[] outputsFromNN = nn.Brain(inputsToNN);

        //Store the outputs from the neural network in variables
        FB = outputsFromNN[0];
        LR = outputsFromNN[1];

        //clamp the values of LR and FB
        LR = Mathf.Clamp(LR, -1, 1);
        FB = Mathf.Clamp(FB, 0.1f, 3);

        //if the agent is the user, use the inputs from the user instead of the neural network
        if (isUser)
        {
            FB = Input.GetAxis("Vertical");
            LR = Input.GetAxis("Horizontal") / 10;
        }

        //change colors
        if (isColored)
        {
            //Color newColor = new Color(energy / maxEnergy * 255, System.Math.Abs(FB * 85), System.Math.Abs(LR * 255));
            //Color newColor = new Color((240 - energy/maxEnergy * 240)/255, (240 - System.Math.Min(totalOffspring, 240))/255,  (240 - elapsed/maxLifeSpan * 240)/255);
            //GetComponent<SpriteRenderer>().color = newColor;
            //Debug.Log((240 - 240 * energy / maxEnergy) + " " + (240 - System.Math.Min(totalOffspring, 240)) + " " + (240 - elapsed / maxLifeSpan * 240));
            //Debug.Log(newColor);

            Color newColor = new Color(1f - elapsed / maxLifeSpan, 1f - energy / maxEnergy, 0.2f + System.Math.Min(totalOffspring*5, 255) / 255);
            renderer.material.color = newColor;
        }
        else
        {
            renderer.material.color = Color.white;
        }

        //Move the agent using the move function
        movement.Move(FB, LR);
    }

    //this function gets called whenever the agent collides with a trigger. (Which in this case is the food)
    void OnCollisionEnter2D(Collision2D col)
    {

        //if the agent collides with a food object, it will eat it and gain energy.
        
        if (col.gameObject.tag == "FoodAI" && canEat)
        {
            fish = col.gameObject.GetComponent<Fish>();
            
            energy += energyGained;
            if (energy > maxEnergy)
            {
                energy = maxEnergy;
            }
            reproductionEnergy += reproductionEnergyGained;
            Destroy(col.gameObject);
            
        }
    }

    public void ManageEnergy()
    {
        float sizeAdded = ((maxSize - minSize) / maxLifeSpan) * Time.deltaTime;
        size += sizeAdded;
        Debug.Log("SIZEADDEDSFSDIJFISJDFISDJFISJ" + sizeAdded);
        Vector3 sizeIncrease = new Vector3(sizeAdded, sizeAdded / 10, 0f);
        gameObject.transform.localScale += sizeIncrease;

        elapsed += Time.deltaTime;
        lifeSpan += Time.deltaTime;
        if (elapsed > maxLifeSpan)
        {
            Destroy(this.gameObject);
        }
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;

            //subtract 1 energy per second
            energy -= 1f;

            //if agent has enough energy to reproduce, reproduce
            if (reproductionEnergy >= reproductionEnergyThreshold)
            {
                reproductionEnergy = 0;
                if (counter.creature < 20)
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
            Destroy(this.gameObject);
            GetComponent<Movement>().enabled = false;
        }

    }

    private IEnumerator FadeOutAndDestroy()
    {
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            float normalizedTime = elapsedTime / fadeDuration;
            Color currentColor = Color.Lerp(startColor, new Color(startColor.r, startColor.g, startColor.b, 0), normalizedTime);
            renderer.material.color = currentColor;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Once fading is complete, destroy the creature
        counter.creature--;
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

        // randomly change size;
        //minSize += ()
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
            child.GetComponent<NN>().layers = GetComponent<NN>().copyLayers();
            
        }
        reproductionEnergy = 0;
        totalOffspring++;

    }
}

