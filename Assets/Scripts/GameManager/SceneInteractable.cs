using UnityEngine;

public class SceneInteractable : MonoBehaviour
{
    public string sceneName;
    public void Interact()
    {
        GameManagerScipr.Instance.LoadScene(sceneName);
    }
}
