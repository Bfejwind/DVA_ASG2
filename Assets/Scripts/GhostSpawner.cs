using System.Collections;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float spawnRate = 5.0f;
    private bool spawnStarted;
    void Update()
    {
        if (!spawnStarted)
        {
            spawnStarted = true;
            StartCoroutine(SpawnGhost());
        }
    }

    private IEnumerator SpawnGhost()
    {
        while (true)
        {
            Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
