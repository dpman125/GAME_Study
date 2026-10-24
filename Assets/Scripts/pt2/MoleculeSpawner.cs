using System.Collections;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    public GameObject glucose;
    public GameObject insulin;
    public float spawnDelay = 5f;
    public int glucosePerSpawn = 1;
    private bool canStartCoroutine;
    private Pt2_GameManager gameManager;
    private float delayDecayRate = .85f;

    private void Start()
    {
        gameManager = gameObject.GetComponent<Pt2_GameManager>();
        StartCoroutine(IncreaseSpawnRate());
        StartCoroutine(SpawnGlucose());

    }
    public void SpawnInsulin()
    {
        // adds slightly random impulse down and towards the right after spawning
        float randomforcex = Random.Range(24f, 12f);
        float randomforcey = Random.Range(-24f, -12f);
        GameObject insulinObj = Instantiate(insulin);
        insulin insulinScript = insulinObj.GetComponent<insulin>();
        insulinScript.Initialize(gameManager);
        Rigidbody2D irb = insulinObj.GetComponent<Rigidbody2D>();
        irb.AddForce(new Vector2(randomforcex, randomforcey), ForceMode2D.Impulse);
        //increment insulin in bloodstream
        gameManager.checkBlood(0, 1);
    }

    public void easy()
    {
        delayDecayRate = .95f;
    }

    public void med()
    {
        delayDecayRate = .85f;
    }

    public void hard()
    {
        delayDecayRate = .75f;
    }

    // recursive Enumerator that spawns x glucose every n seconds
    IEnumerator SpawnGlucose()
    {
        for (int i = 0; i < glucosePerSpawn; i++)
        {
            float randomforcex = Random.Range(24f, 12f);
            float randomforcey = Random.Range(-24f, -12f);
            GameObject glucoseObj = Instantiate(glucose);
            Rigidbody2D grb = glucoseObj.GetComponent<Rigidbody2D>();
            grb.AddForce(new Vector2(randomforcex, randomforcey), ForceMode2D.Impulse);
            gameManager.checkBlood(1, 0);
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnGlucose());

    }

    IEnumerator IncreaseSpawnRate()
    {
        yield return new WaitForSeconds(10);
        spawnDelay *= delayDecayRate;
        StartCoroutine(IncreaseSpawnRate());

    }
}
