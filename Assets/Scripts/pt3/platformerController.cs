using UnityEngine;

public class platformerController : MonoBehaviour
{

    public int direction;
    private bool isOnGround;
    Rigidbody2D rb;

    [Header("Player Stats")]
    public float walkSpeed;
    public float runSpeed;
    public float jumpForce;
    public int bloodSugar;
    public bool doubleJump;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void handleLeftInput()
    {
        direction = -1;
    }
    public void handleRightInput()
    {
        direction = 1;
    }
    public void inputRelease()
    {
        direction = 0;
    }
    public void Jump()
    {
        if (isOnGround)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

    }
    private void Update()
    {
        if (direction != 0)
        {
            Vector3 move = new Vector3(direction * walkSpeed * Time.deltaTime, 0f, 0f);
            transform.Translate(move);
        }
        Debug.Log(rb.linearVelocityY);
        if (rb.linearVelocityY < 0.01f && rb.linearVelocityY > -0.01f)
        {
            isOnGround = true;
        }
        else
        {
            isOnGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<food>())
        {
            handleEating(other.gameObject.GetComponent<food>());
            Destroy(other.gameObject);
        }
    }

    private void handleEating(food food)
    {
        bloodSugar += food.sugar;

    }
}
