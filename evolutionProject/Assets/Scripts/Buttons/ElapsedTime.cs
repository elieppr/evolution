using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ElapsedTime : MonoBehaviour
{
    public TMP_Text elapsedTimeText;
    private float startTime;

    private void Start()
    {
        startTime = Time.time; // Record the initial time
    }

    private void Update()
    {
        float elapsedTime = Time.time - startTime; // Calculate elapsed time
        elapsedTimeText.text = $"{elapsedTime.ToString("0.000")}";
    }
}
