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
    public void CheckAnswer()
    {
        int.TryParse(input.text,out int result);
        if (result == answer)
        {
            correctTick.SetActive(true);
            //Play Correct SFX
        }
        else
        {
            //play wrong SFX
            Debug.Log("Wrong Answer");
        }
    }
}
