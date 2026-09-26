using UnityEngine;

public class insulin : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroys lock(transport protien) and key(insulin)
        if (collision.CompareTag("CellLock"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
