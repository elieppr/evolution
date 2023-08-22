using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;

public class Counter : MonoBehaviour
{
    public TMP_Text counterText;
    public int creature;
    private readonly object creatureLock = new object(); // Lock object
    public int fish;
    private readonly object fishLock = new object(); // Lock object
    public int fishfood;
    private readonly object ffoodLock = new object(); // Lock object
    private void FixedUpdate()
    {
        
        Debug.Log(creature + " " + fish + " " + fishfood);

    }

    public void CreatureIncrementCounter()
    {
        Interlocked.Increment(ref creature);
    }
    public void CreatureDecrementCounter()
    {
        Interlocked.Decrement(ref creature);
    }
    public int CreatureGetCounter()
    {
        return Interlocked.CompareExchange(ref creature, 0, 0);
    }

    public void FishIncrementCounter()
    {
        Interlocked.Increment(ref fish);
    }
    public void FishDecrementCounter()
    {
        Interlocked.Decrement(ref fish);
    }
    public int FishGetCounter()
    {
        return Interlocked.CompareExchange(ref fish, 0, 0);
    }

    public void FFoodIncrementCounter()
    {
        Interlocked.Increment(ref fishfood);
    }
    public void FFoodDecrementCounter()
    {
        Interlocked.Decrement(ref fishfood);
    }
    public int FFoodGetCounter()
    {
        return Interlocked.CompareExchange(ref fishfood, 0, 0);
    }

    public void UpdateCounterText()
    {
        counterText.text = $"Penguins: {creature}\nFish: {fish}\nFishfood: {fishfood}";
    }
}
