using UnityEngine;
using UnityEngine.Events;

public class VideoHotspot : MonoBehaviour
{
    [Header("Hover")]
    [SerializeField] private GameObject indicator;
    [Header("Interaction Event")]
    [Tooltip("Assign actions here via the Unity Inspector (e.g., Load scene, change video, play audio).")]
    public UnityEvent onHotspotClicked;
    private void Start()
    {
        indicator.SetActive(false);
    }

    public void Interact()
    {
        Debug.Log($"Hotspot clicked: {gameObject.name}");
        
        // Execute whatever functions you link inside the Unity Inspector
        onHotspotClicked?.Invoke();
    }
    public void SetHighlighted(bool highlighted)
    {
        indicator.SetActive(highlighted);
    }
}
