using UnityEngine;
using TMPro;
public class KeyCardUnlock : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private int answer;
    [SerializeField] private GameObject keyCardGetVid;
    [SerializeField] private GameObject keyCardInv;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip wrongSFX;
    [SerializeField] private GhostSpawner ghostSpawner;
    [SerializeField] private PlayerHealth playerHp;
    private void Start()
    {
        keyCardGetVid.SetActive(false);
    }
    public void CheckAnswer()
    {
        int.TryParse(input.text,out int result);
        if (result == answer)
        {
            //Play Correct SFX
            audioSource.PlayOneShot(correctSFX);
            ghostSpawner.stopSpawn = true;
            keyCardGetVid.SetActive(true);
            keyCardInv.SetActive(true);
            GameManagerScipr.Instance.keyCardGet();
        }
        else
        {
            //play wrong SFX
            playerHp.TakeDamage(20.0f);
            audioSource.PlayOneShot(wrongSFX);
            
        }
    }
}
