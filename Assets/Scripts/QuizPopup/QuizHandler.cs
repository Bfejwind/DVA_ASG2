using TMPro;
using UnityEngine;

public class QuizHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private int answer;
    [SerializeField] private GameObject correctTick;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip wrongSFX;
    [SerializeField] private PlayerHealth playerHp;
    private void Start()
    {
        correctTick.SetActive(false);
    }
    public void CheckAnswer()
    {
        int.TryParse(input.text,out int result);
        if (result == answer)
        {
            audioSource.PlayOneShot(correctSFX);
            correctTick.SetActive(true);
            //Play Correct SFX
        }
        else
        {
            //play wrong SFX
            playerHp.TakeDamage(20.0f);
            audioSource.PlayOneShot(wrongSFX);
            correctTick.SetActive(false);
        }
    }
}
