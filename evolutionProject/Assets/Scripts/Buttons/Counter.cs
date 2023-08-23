using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Counter : MonoBehaviour
{
    public TMP_Text counterText;
    public int creature;
    public int fish;
    public int fishfood;
    private void FixedUpdate()
    {
        
        fishfood = GameObject.FindGameObjectsWithTag("FishFood").Length;
        fish = GameObject.FindGameObjectsWithTag("FoodAI").Length;
        creature = GameObject.FindGameObjectsWithTag("Agent").Length;

        UpdateCounterText();
    }

    public void UpdateCounterText()
    {
        counterText.text = $"Penguins: {creature}\nFish: {fish}\nFishfood: {fishfood}";
    }
}
