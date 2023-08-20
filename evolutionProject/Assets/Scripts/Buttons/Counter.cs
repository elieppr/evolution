using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public TMP_Text counterText;
    private GameObject[] AgentList;
    private GameObject[] FishList;
    private GameObject[] FishfoodList;

    private void Start()
    {
        
    }

    void FixedUpdate()
    {  
        AgentList = GameObject.FindGameObjectsWithTag("Agent");
        FishList = GameObject.FindGameObjectsWithTag("FoodAI");
        FishfoodList = GameObject.FindGameObjectsWithTag("FishFood");
    }

    public void UpdateCounterText()
    {
        counterText.text = $"Penguins: {AgentList.Length}\nFish: {FishList.Length}\nFishfood: {FishfoodList.Length}";
    }
}
