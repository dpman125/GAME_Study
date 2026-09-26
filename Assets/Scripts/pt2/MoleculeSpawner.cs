using System.Collections;
using UnityEngine;

public class MoleculeSpawner : MonoBehaviour
{
    public GameObject glucose;
    public GameObject insulin;
    public float spawnDelay = 5f;
    public int glucosePerSpawn = 2;
    private bool canStartCoroutine;

    private void Start()
    {
        StartCoroutine(SpawnGlucose());

    }
    public void SpawnInsulin()
    {
        float randomforcex = Random.Range(12f, 8f);
        float randomforcey = Random.Range(-12f, -8f);
        GameObject insulinObj = Instantiate(insulin);
        Rigidbody2D irb = insulinObj.GetComponent<Rigidbody2D>();
        irb.AddForce(new Vector2(randomforcex, randomforcey), ForceMode2D.Impulse);
    }

    // recursive Enumerator that spawns x glucose every n seconds
    IEnumerator SpawnGlucose()
    {
        for (int i = 0; i < glucosePerSpawn; i++)
        {
            float randomforcex = Random.Range(12f, 8f);
            float randomforcey = Random.Range(-12f, -8f);
            GameObject glucoseObj = Instantiate(glucose);
            Rigidbody2D grb = glucoseObj.GetComponent<Rigidbody2D>();
            grb.AddForce(new Vector2(randomforcex, randomforcey), ForceMode2D.Impulse);
            yield return new WaitForSeconds(.1f);
        }
        yield return new WaitForSeconds(spawnDelay);
        StartCoroutine(SpawnGlucose());

    }
}
