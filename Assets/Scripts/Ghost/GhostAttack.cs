using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GhostAttack : MonoBehaviour
{
    private float lifeSpan = 20.0f;
    [SerializeField] private Transform player;
    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float damage = 50;
    private bool seen;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip ghostSpawnSFX;
    private void Awake()
    {
        if (player == null)
        {
            player = GameObject.Find("Main Camera").transform;
        }
    }
    private void Start()
    {
        Destroy(gameObject,lifeSpan);
        //Play ghostSpawn
        audioSource.PlayOneShot(ghostSpawnSFX);
    }
    // Update is called once per frame
    void Update()
    {
        if (!seen)
        {
            Vector3 direction = player.position - transform.position;
            transform.rotation = Quaternion.LookRotation(direction);
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
    public void StartVanish()
    {
        StartCoroutine(Vanish());
    }
    private IEnumerator Vanish()
    {
        seen = true;
        yield return new WaitForSeconds(1.0f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHealth>(out PlayerHealth playerhp))
        {
            playerhp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }


}
