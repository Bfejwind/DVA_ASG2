using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float currentHealth,maxHealth = 100f;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private float damageAmt = 50.0f;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip hurtSFX;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage()
    {
        audioSource.PlayOneShot(hurtSFX);
        currentHealth -= damageAmt;
        healthSlider.value = currentHealth;
    }
}
