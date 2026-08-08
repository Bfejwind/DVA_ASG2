using UnityEngine;
using TMPro;
public class KeyCardUnlock : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private int answer;
    [SerializeField] private GameObject keyCardGetVid;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip wrongSFX;
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
            keyCardGetVid.SetActive(true);
        }
        else
        {
            //play wrong SFX
            audioSource.PlayOneShot(wrongSFX);
            
        }
    }
}
