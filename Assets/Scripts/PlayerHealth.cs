using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth,maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hurtSFX;
    [SerializeField] private GameObject lossPanel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (healthSlider != null)
        {
            currentHealth = maxHealth;
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }

    public void TakeDamage(float damageAmt)
    {
        audioSource.PlayOneShot(hurtSFX);
        currentHealth -= damageAmt;
        healthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            lossPanel.SetActive(true);
        }
    }
    public void GameManagerLoadScene(string sceneName)
    {
        GameManagerScipr.Instance.StartLoadScene(sceneName);
    }
    public void GameManagerQuit()
    {
        GameManagerScipr.Instance.QuitGame();
    }
    public void GameManagerBonkGet()
    {
        GameManagerScipr.Instance.BonkGet();
    }
    public void GameManagerKeyGet()
    {
        GameManagerScipr.Instance.keyCardGet();
    }
}
