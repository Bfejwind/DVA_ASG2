using UnityEngine;
using TMPro;
using System.Collections;

public class EscapeHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private int answer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip wrongSFX;
    [SerializeField] private PlayerHealth playerHp;
    public void StartCheckAnswer()
    {
        StartCoroutine(CheckAnswer());
    }
    public IEnumerator CheckAnswer()
    {
        int.TryParse(input.text,out int result);
        if (result == answer)
        {
            //Play Correct SFX
            audioSource.PlayOneShot(correctSFX);
            yield return new WaitForSeconds(1.0f);
            GameManagerScipr.Instance.StartLoadScene(sceneToLoad);
        }
        else
        {
            //play wrong SFX
            playerHp.TakeDamage(20.0f);
            audioSource.PlayOneShot(wrongSFX);
            yield return null;
        }
    }
}
