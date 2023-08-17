using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatureSpawner : MonoBehaviour
{
    public GameObject agentPrefab;
    private GameObject[] agentList;
    public int floorScale = 1;
    public Sprite Csprite;

    // Update is called once per frame
    void FixedUpdate()
    {
        agentList = GameObject.FindGameObjectsWithTag("Agent");

        // if there are no agents in the scene, spawn one at a random location. 
        // This is to ensure that there is always at least one agent in the scene.
        if (agentList.Length < 2)
        {
            SpawnCreature();
        }
    }

    void SpawnCreature()
    {
        int x = Random.Range(-100, 101) * floorScale;
        int y = Random.Range(-100, 101) * floorScale;
        GameObject agent = Instantiate(agentPrefab, new Vector3((float)x, (float)y, 0.0f), Quaternion.identity);

        // Set the tag of the instantiated creature to "Agent"
        agent.tag = "Agent";

        // Add a SpriteRenderer component and set the sprite
        //SpriteRenderer spriteRenderer = agent.AddComponent<SpriteRenderer>();
        //if (spriteRenderer == null) { Debug.Log("NULLLL"); }
        //spriteRenderer.sprite = Csprite; // Replace 'yourSprite' with the sprite you want to assign

        agent.SetActive(true);
    }
}