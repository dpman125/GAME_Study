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
        player = GameObject.FindWithTag("Player");

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(player.transform.position.normalized * enemySpeed, ForceMode2D.Impulse);
        randSpeed = (Random.Range(enemySpeed - 2, enemySpeed + 2) * Time.deltaTime);
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
}

