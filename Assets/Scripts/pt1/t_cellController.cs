using System.Collections;
using UnityEngine;

public class t_cellController : MonoBehaviour
{

    public float enemySpeed = 5;
    public float attackCooldown = 5;
    private GameObject player;
    Rigidbody2D rb;
    private float randSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        float lifespan = 5;
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(player.transform.position.normalized * enemySpeed, ForceMode2D.Impulse);
        StartCoroutine(DestroyTcell(lifespan));
        randSpeed = (Random.value * Time.deltaTime * enemySpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(Vector3.MoveTowards(rb.position, player.GetComponent<Rigidbody2D>().position, randSpeed));
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
        for (int i = 0; i < attackCooldown; i++)
        {
            yield return new WaitForSeconds(3);
            rb.AddForce(player.transform.position.normalized * enemySpeed, ForceMode2D.Impulse);
        }
        Destroy(gameObject);

    }
}

