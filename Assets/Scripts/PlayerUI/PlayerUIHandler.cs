using UnityEngine;

public class PlayerUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject bonkerInv;
    [SerializeField] private GameObject keyCardInv;
    [SerializeField] private GameObject bonkerMessage;
    [SerializeField] private GameObject keyCardMessage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bonkerInv.SetActive(false);
        keyCardInv.SetActive(false);
        bonkerMessage.SetActive(false);
        keyCardMessage.SetActive(false);
        if (GameManagerScipr.Instance.bonkerGotten)
        {
            bonkerInv.SetActive(true);
        }
        if (GameManagerScipr.Instance.keyCardGotten)
        {
            keyCardInv.SetActive(true);
        }
    }

    
}
