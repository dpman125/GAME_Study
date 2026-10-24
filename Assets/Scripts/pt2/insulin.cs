using UnityEngine;

public class insulin : MonoBehaviour
{

    public Pt2_GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // destroys lock(transport protien) and key(insulin)
        if (collision.CompareTag("CellLock"))
        {
            //removes insulin from bloodStream before destroying the lock and itself
            gameManager.checkBlood(0, -1);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    // gameManager initialized externally
    public void Initialize(Pt2_GameManager manager)
    {
        gameManager = manager;
    }
}
