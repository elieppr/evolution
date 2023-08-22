using UnityEngine;
using UnityEngine.UI;

public class DrawButton : MonoBehaviour
{
    public CameraPanZoom cameraPanningScript;
    public MapGenerator mapScript;

    private bool isDrawingEnabled = false;

    private void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(ToggleDrawing);
    }

    private void ToggleDrawing()
    {
        isDrawingEnabled = !isDrawingEnabled;

        // Toggle camera panning script
        if (cameraPanningScript != null)
        {
            cameraPanningScript.enabled = !isDrawingEnabled;
        }

        // Toggle isDraw on Map GameObject
        mapScript.useBrush = isDrawingEnabled;
        
    }
}
