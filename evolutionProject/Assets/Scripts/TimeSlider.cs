using UnityEngine;
using UnityEngine.UI;

public class TimeSlider : MonoBehaviour
{
    public TimeControl timeControl;
    public Slider timeSlider;

    public void OnSliderValueChanged()
    {
        float newTimeScale = timeSlider.value;
        timeControl.SetTimeScale(newTimeScale);
    }
}
