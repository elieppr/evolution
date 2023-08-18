using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject agentPrefab;
    private GameObject[] agentList;
    public int floorScale = 1;
    public Sprite Csprite;

    // Update is called once per frame
    void FixedUpdate()
    {
        agentList = GameObject.FindGameObjectsWithTag("FoodAI");
        // if there are no agents in the scene, spawn one at a random location. 
        // This is to ensure that there is always at least one agent in the scene.
        if (agentList.Length < 20)
        {
            SpawnCreature();
        }
    }

    void SpawnCreature()
    {
        int x = Random.Range(-100, 101) * floorScale;
        int y = Random.Range(-100, 101) * floorScale;
        GameObject agent = Instantiate(agentPrefab, new Vector3((float)x, (float)y, 0.0f), Quaternion.identity);

        // Set the tag of the instantiated creature to "Food"
        agent.tag = "FoodAI";
        agent.SetActive(true);
    }
}