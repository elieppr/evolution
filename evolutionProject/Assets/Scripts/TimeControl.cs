using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeControl : MonoBehaviour
{
    public Slider timeSlider;
    public TMP_Text counterText;
    public void SetTimeScale(float newScale)
    {
        Time.timeScale = newScale;
        Debug.Log("NEWWWWWWWWWWWWWWWWWWWWWSCALE: " + newScale);

        UpdateCounterText(newScale);
    }


    public void UpdateCounterText(float newScale)
    {
        counterText.text = $"{newScale.ToString("0.000")}";
    }
}

