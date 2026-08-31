using System.Collections;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject T_cell;
    public float spawnRate;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(SpawnEnemy(spawnRate));
    }

    IEnumerator SpawnEnemy(float delayInSeconds)
    {
        // Wait for the specified seconds
        yield return new WaitForSeconds(delayInSeconds);

        Instantiate(T_cell);
        StartCoroutine(SpawnEnemy(spawnRate));
    }

}