using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painting : MonoBehaviour
{
    public float minTimeToSpawn = 10f;
    public float maxTimeToSpawn = 30f;
    public Transform spawnPoint;
    public GameObject[] possibleEnemies;
    private bool isSpawning = false;
    public SpriteRenderer gfx;

    void Update()
    {
        if (isSpawning == false)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        isSpawning = true;
        if (spawnPoint != null)
        {
            GameObject newEnemy = Instantiate(possibleEnemies[Random.Range(0, possibleEnemies.Length)], spawnPoint.position, Quaternion.identity, spawnPoint);
        }
        yield return new WaitForSeconds(Random.Range(minTimeToSpawn, maxTimeToSpawn));
        isSpawning = false;
    }
}
