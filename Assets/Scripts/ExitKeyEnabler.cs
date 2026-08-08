using UnityEngine;

public class ExitKeyEnabler : MonoBehaviour
{
    [SerializeField] private GameObject keyCardInv;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManagerScipr.Instance.keyCardGotten)
        {
            keyCardInv.SetActive(true);
        }
    }

    
}
