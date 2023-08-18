using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public Slider timeSlider;
    public void SetTimeScale(float newScale)
    {
        Time.timeScale = newScale;
        Debug.Log("NEWWWWWWWWWWWWWWWWWWWWWSCALE: " + newScale);
    }
}

