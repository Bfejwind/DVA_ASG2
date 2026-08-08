using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScipr : MonoBehaviour
{
    public static GameManagerScipr Instance {get; private set;}
    public bool bonkerGotten;
    public bool keyCardGotten;
    public bool labUnlocked;
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
    public void BonkGet()
    {
        bonkerGotten = true;
    }
    public void keyCardGet()
    {
        keyCardGotten = true;
    }
    public void UnlockLab()
    {
        labUnlocked = true;
    }
}
