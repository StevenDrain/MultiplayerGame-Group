using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform character1; // Assign your first character in the Inspector
    public Transform character2; // Assign your second character in the Inspector
    public float offsetY = 1f; // Y offset for the camera position
    public float smoothing = 0.1f; // Smoothing factor for camera movement

    public float minZoom = -10f; // Minimum zoom distance (how close the camera can be)
    public float maxZoom = -5f; // Maximum zoom distance (how far the camera can be)
    public float zoomFactor = 1.0f; // Factor to adjust camera distance based on character separation
    public float zoomSpeed = 0.5f; // Speed of zoom transition

    private float currentZoom;

    private void Start()
    {
        currentZoom = maxZoom; // Start with the maximum zoom
    }

    private void LateUpdate()
    {
        if (character1 != null && character2 != null)
        {
            // Calculate the midpoint between the two characters
            Vector3 midpoint = (character1.position + character2.position) / 2;

            // Calculate the distance between the two characters
            float distance = Vector3.Distance(character1.position, character2.position);

            // Calculate the target Z offset based on the distance
            float targetZoom = Mathf.Lerp(maxZoom, minZoom, (distance * zoomFactor) / 40.0f); // Scale by distance

            // Smoothly interpolate the zoom based on zoomSpeed
            currentZoom = Mathf.Lerp(currentZoom, targetZoom, zoomSpeed * Time.deltaTime);

            // Set the camera's position to the midpoint with an offset
            Vector3 newPosition = new Vector3(midpoint.x, midpoint.y + offsetY, midpoint.z + currentZoom);

            // Smoothly move the camera towards the new position
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothing);
        }
    }
}
