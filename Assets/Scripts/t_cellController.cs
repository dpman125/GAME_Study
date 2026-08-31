using UnityEngine;

public class t_cellController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //forces range from -2 to 2
        float randx = (Random.value * 4) - 2;
        float randy = (Random.value * 4) - 2;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(new Vector3(randx, randy, 0f), ForceMode2D.Impulse);
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
}

