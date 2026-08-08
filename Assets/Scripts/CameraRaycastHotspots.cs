using UnityEngine;
using UnityEngine.InputSystem; // Required for New Input System

public class CameraRaycastHotspots : MonoBehaviour
{
    [Header("Raycast Settings")]
    [Tooltip("How far away the camera can detect hotspots.")]
    public float maxDistance = 100f;
    [Tooltip("The Layer you assigned your Hotspots to.")]
    public LayerMask hotspotLayer;
    public LayerMask ghostLayer;

    [Header("Targeting Mode")]
    [Tooltip("True: Raycasts from center of screen (VR/Crosshair). False: Raycasts from mouse cursor.")]
    public bool centerOfScreenMode = true;

    private Camera cam;
    private VideoHotspot currentHotspot;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        // 1. Generate the ray based on selected targeting mode
        Ray ray;
        if (centerOfScreenMode)
        {
            // Shoots a ray directly straight forward out of the camera lens center
            ray = new Ray(transform.position, transform.forward);
        }
        else
        {
            // Shoots a ray from the absolute position of the mouse cursor on screen
            Vector2 mousePos = Mouse.current.position.ReadValue();
            ray = cam.ScreenPointToRay(mousePos);
        }

        // 2. Perform the raycast calculation
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, maxDistance, ghostLayer))
        {
            GhostAttack ghost = hit.collider.GetComponent<GhostAttack>();
            ghost.StartVanish();
        }
        if (Physics.Raycast(ray, out hit, maxDistance, hotspotLayer))
        {
            VideoHotspot hotspot = hit.collider.GetComponent<VideoHotspot>();
            if (hotspot != currentHotspot)
            {
                if (currentHotspot != null)
                {
                    currentHotspot.SetHighlighted(false);
                }
                currentHotspot = hotspot;
                if (currentHotspot != null)
                {
                    currentHotspot.SetHighlighted(true);
                }
            }
            
            // Optional visual indicator: Draw green line in Scene view when hitting something
            Debug.DrawLine(ray.origin, hit.point, Color.green);

            // Check if the player clicked/tapped while looking at the hotspot
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                // Attempt to trigger the event on the targeted hotspot
                if (hotspot != null)
                {
                    hotspot.Interact();
                }
            }
        }
        else
        {
            // Draw red line in Scene view if nothing is hit
            Debug.DrawLine(ray.origin, ray.origin + ray.direction * maxDistance, Color.red);
            if (currentHotspot != null)
            {
                currentHotspot.SetHighlighted(false);
                currentHotspot = null;
            }
        }
    }
}
