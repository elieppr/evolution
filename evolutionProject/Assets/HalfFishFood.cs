using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HalfFishFood : MonoBehaviour
{

    private GameObject[] fishFood;
    // Start is called before the first frame update
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(KillHalf);
    }

    public void KillHalf()
    {
        fishFood = GameObject.FindGameObjectsWithTag("FishFood");

        int remainingFishFoodCount = fishFood.Length / 2; // Calculate the remaining fish food count

        int numFishFoodToDestroy = Mathf.Max(0, fishFood.Length - remainingFishFoodCount);

        for (int i = 0; i < numFishFoodToDestroy; i++)
        {
            int randomIndex = Random.Range(0, fishFood.Length);
            Destroy(fishFood[randomIndex].gameObject);
        }
    }
}
