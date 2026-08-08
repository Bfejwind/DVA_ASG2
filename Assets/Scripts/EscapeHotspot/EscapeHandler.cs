using UnityEngine;
using TMPro;

public class EscapeHandler : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private int answer;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip correctSFX;
    [SerializeField] private AudioClip wrongSFX;
    public void CheckAnswer()
    {
        int.TryParse(input.text,out int result);
        if (result == answer)
        {
            //Play Correct SFX
            GameManagerScipr.Instance.LoadScene(sceneToLoad);
        }
        else
        {
            //play wrong SFX
            Debug.Log("Wrong Answer");
            
        }
    }
}
