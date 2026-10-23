using UnityEngine;

public class tinyForce : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    int health = 5;
    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector2(Random.value * 2, Random.value * 2), ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Took Hit");
            transform.localScale /= 1.5f;
            health--;

        }
    }
}
