using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnFishFood : MonoBehaviour
{
    public GameObject fishfoodPrefab;
    private bool spawning = false;
    public Transform brush;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleSpawning);
        brush.localScale = Vector3.one * 0.2f;
    }

    public void ToggleSpawning()
    {
        spawning = !spawning;
        
    }

    private void Update()
    {
        brush.gameObject.SetActive(spawning);
        //Debug.Log(Input.GetMouseButton(0) + " AAAAAAAAAAAAAAAAAAAAA");
        if (spawning)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("CLICKERDSIHIHIHIHIHI");
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                GameObject agent = Instantiate(fishfoodPrefab, clickPosition, Quaternion.identity);
                agent.tag = "FishFood";
                agent.SetActive(true);
            }
            Vector2 mousePos = InputHelper.MouseWorldPos;
            brush.position = new Vector3(mousePos.x, mousePos.y, -1);
        }
    }

}
