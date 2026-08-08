using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScipr : MonoBehaviour
{
    public static GameManagerScipr Instance {get; private set;}
    public bool bonkerGotten;
    public bool keyCardGotten;
    public bool labUnlocked;
    [SerializeField] private GameObject bonkerInv;
    [SerializeField] private GameObject keyCardInv;
    [SerializeField] private AudioSource SFXSource;
    [SerializeField] private AudioClip footsteps;
    [SerializeField] private AudioSource BGMSource;
    [SerializeField] private AudioClip bgm;
    private void Awake()
    {
        PlayBGM();
        if (bonkerGotten)
        {
            bonkerInv.SetActive(true);
        }
        if (keyCardGotten)
        {
            keyCardInv.SetActive(true);
        }
        if (Instance != this && Instance != null)
        {
            Destroy(gameObject);
            return;
        }     
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void StartLoadScene(string sceneName)
    {
        StartCoroutine(LoadScene(sceneName));
    }
    public IEnumerator LoadScene(string sceneName)
    {
        SFXSource.PlayOneShot(footsteps);
        yield return new WaitForSeconds(3.0f);
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
    public void PlayBGM()
    {
        BGMSource.clip = bgm;
        BGMSource.loop = true;
        BGMSource.Play();
    }
    public void Escape()
    {
        StartLoadScene("Escaped");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
