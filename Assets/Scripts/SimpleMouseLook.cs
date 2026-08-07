using UnityEngine;
using UnityEngine.InputSystem; // Required for the new system

public class SimpleMouseLook : MonoBehaviour
{
    public float sensitivity = 0.1f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    void Start()
    {
        // Locks the mouse cursor to the center of the game view
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        // Read mouse delta movement directly from the new Input System
        Vector2 mouseDelta = Mouse.current.delta.ReadValue();

        rotationX += mouseDelta.x * sensitivity;
        rotationY -= mouseDelta.y * sensitivity;
        
        // Clamp vertical look so you can't flip upside down
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        // Apply the rotation to the camera
        transform.localRotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Press Escape key to free your mouse cursor
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
