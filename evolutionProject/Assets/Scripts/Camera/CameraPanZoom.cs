using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPanZoom : MonoBehaviour
{
    public float panSpeedBase = 2.0f;
    public float zoomSensitivity = 0.5f;
    public float maxZoom = 10.0f;
    public float minZoom = 2.0f;

    private Vector3 lastMousePosition;
    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // Calculate zoom amount based on scroll wheel input
        float zoomAmount = -Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;

        // Calculate new camera orthographic size
        float newSize = Mathf.Clamp(mainCamera.orthographicSize + zoomAmount, minZoom, maxZoom);

        // Apply the new camera orthographic size
        mainCamera.orthographicSize = newSize;

        // Adjust panning speed based on zoom level
        float currentPanSpeed = panSpeedBase * mainCamera.orthographicSize;

        // Check for right mouse button down
        if (Input.GetMouseButtonDown(1))
        {
            lastMousePosition = Input.mousePosition;
        }

        // Check for right mouse button dragging
        if (Input.GetMouseButton(1))
        {
            // Calculate mouse movement
            Vector3 mouseDelta = lastMousePosition - Input.mousePosition;

            // Calculate camera movement based on mouse movement
            Vector3 move = new Vector3(mouseDelta.x, mouseDelta.y, 0) * currentPanSpeed * Time.deltaTime;

            // Apply movement to the camera's position
            transform.Translate(move, Space.Self);

            // Store the current mouse position for the next frame
            lastMousePosition = Input.mousePosition;
        }
    }
}
