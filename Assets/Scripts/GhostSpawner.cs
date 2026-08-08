using System.Collections;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float spawnRate = 5.0f;
    private bool spawnStarted;
    public bool stopSpawn;
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
        while (!stopSpawn)
        {
            Instantiate(ghostPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
