using System.Collections;
using UnityEngine;

public class HintHandler : MonoBehaviour
{
    private float hintduration = 5.0f;
    [SerializeField] private GameObject hintTxt;
    public void StartHintDisplay()
    {
        StartCoroutine(DisplayHint());
    }
    private IEnumerator DisplayHint()
    {
        hintTxt.SetActive(true);
        yield return new WaitForSeconds(hintduration);
        hintTxt.SetActive(false);
    }
}
