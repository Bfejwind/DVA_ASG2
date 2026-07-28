using UnityEngine;
using UnityEngine.Events;

public class VideoHotspot : MonoBehaviour
{
    [Header("Interaction Event")]
    [Tooltip("Assign actions here via the Unity Inspector (e.g., Load scene, change video, play audio).")]
    public UnityEvent onHotspotClicked;

    public void Interact()
    {
        Debug.Log($"Hotspot clicked: {gameObject.name}");
        
        // Execute whatever functions you link inside the Unity Inspector
        onHotspotClicked?.Invoke();
    }
}
