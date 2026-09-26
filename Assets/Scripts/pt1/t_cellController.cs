using System.Collections;
using UnityEngine;

public class t_cellController : MonoBehaviour
{

    public float enemySpeed = 5;
    public float attackCooldown = 5;
    private GameObject player;
    Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        float lifespan = 5;
        player = GameObject.FindWithTag("Player");

        float randx = (Random.value * (enemySpeed * 2)) - enemySpeed;
        float randy = (Random.value * (enemySpeed * 2)) - enemySpeed;
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(player.transform.position.normalized * enemySpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyTcell(lifespan));
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colliding with " + collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator DestroyTcell(float lifespan)
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(attackCooldown);
            rb.AddForce(player.transform.position.normalized * enemySpeed, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}

