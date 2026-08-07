using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScipr : MonoBehaviour
{
    public static GameManagerScipr Instance {get; private set;}
    private void Awake()
    {
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }     
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
