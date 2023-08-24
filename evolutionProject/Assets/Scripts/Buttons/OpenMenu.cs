using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject settingsCanvas;
    public Toggle toggle;
    public SettingsManager settings;
    
    public void ToggleMenuCanvas()
    {
        if (toggle.isOn)
        {
            settingsCanvas.SetActive(true);
            settings.PauseGame();
        }
        else
        {
            settingsCanvas.SetActive(false);
            settings.ResumeGame();
        }
    }
}
