using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public float spawnRate = 1;
    public int floorScale = 1;
    public GameObject myPrefab;
    private GameObject[] agentList;
    public float timeElapsed = 0;
    public Counter counter;
    public SettingsManager settings;
    public LayerMask collisionLayer;

    public int minFishFood;

    void Start()
    {

        // Spawn food at random locations at the start of the game
        for (int i = 0; i < 200; i++)
        {
            SpawnFood();
        }
    }

    // FixedUpdate is called once per physics frame
    void FixedUpdate()
    {
        agentList = GameObject.FindGameObjectsWithTag("FishFood");
        // if there are no agents in the scene, spawn one at a random location. 
        // This is to ensure that there is always at least one agent in the scene.
        if (agentList.Length < settings.minFF)
        {
            SpawnFood();
        }
        //spawn food every second with timeElapsed
        timeElapsed += Time.deltaTime;
        if (!(settings.spawnFF == 0) && timeElapsed >= 1/settings.spawnFF && counter.fishfood < settings.maxFF)
        {
            timeElapsed = timeElapsed % spawnRate;
            SpawnFood();
        }
    }

    void SpawnFood()
    {
        int x = Random.Range(-200, 201) * floorScale;
        int y = Random.Range(-150, 151) * floorScale;

        //GameObject agent = Instantiate(myPrefab, new Vector3((float)x, (float)y, 0.0f), Quaternion.identity);
        //agent.tag = "FishFood";



        Vector3 worldPosition = new Vector3(x , y , 0f);
        Vector2 pointToCheck = new Vector2(x, y);

        // Cast a ray at the world position
        RaycastHit2D hit = Physics2D.Raycast(pointToCheck, Vector2.zero, 0f, collisionLayer);

        // Check if the ray hit something
        if (hit.collider != null)
        {
            //Debug.Log("HIT????????????????????" + " " + x + " " + y);
            SpawnFood();
        }
        else
        {
         
            GameObject agent = Instantiate(myPrefab, new Vector3((float)x, (float)y, 0.0f), Quaternion.identity);
            agent.tag = "FishFood";
            agent.SetActive(true);
        }
                    
    }
}