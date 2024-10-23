using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawner : MonoBehaviour
{
    public GameObject[] sunPrefabs;
    public Transform snowman;
    public float spawnPosX = 20;
    public float spawnRangeY = 5;
    public float spawnInterval;
    private float startDelay = 2;
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnSuns());
    }

    private IEnumerator SpawnSuns()
    {
        yield return new WaitForSeconds(startDelay);

        while (gameManager.isGameActive)
        {
            SpawnRandomSun();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnRandomSun()
    {
        float spawnPosY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0);

        int sunIndex = Random.Range(0, sunPrefabs.Length);
        GameObject sun = Instantiate(sunPrefabs[sunIndex], spawnPos, sunPrefabs[sunIndex].transform.rotation);

        Rigidbody rb = sun.GetComponent<Rigidbody>();
        if (rb != null && snowman != null)
        {
            Vector3 direction = (snowman.position - sun.transform.position).normalized;
            rb.velocity = direction * 5f;
        }
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
    }
}
