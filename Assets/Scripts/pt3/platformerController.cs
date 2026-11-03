using UnityEngine;
using UnityEngine.UI;

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
    public UIManager UIManager;

    private SpriteRenderer sprite;

    public int loseRange = 280;
    public int dangerRange = 240;
    public int warningRange = 180;

    public Image MonitorBackground;
    public GameObject GameOverScreen;

    public Pt3UI_Manager UIManager3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        Time.timeScale = 1f;
        checkBlood();
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

        if (Input.GetKeyDown(KeyCode.D))
        {
            direction = 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            direction = -1;
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            direction = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if (direction != 0)
        {
            Vector3 move = new Vector3(direction * walkSpeed * Time.deltaTime, 0f, 0f);
            transform.Translate(move);
            sprite.flipX = direction > 0f ? true : false;
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
    public void checkBlood()
    {
        if (bloodSugar > loseRange)
        {
            GameOver();
        }
        else if (bloodSugar >= dangerRange)
        {
            MonitorBackground.color = Color.orangeRed;
        }
        else if (bloodSugar >= warningRange)
        {
            MonitorBackground.color = Color.yellow;
        }
        else
        {
            MonitorBackground.color = Color.limeGreen;
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
        if (food.recipie)
        {
            UIManager3.UpdateRecipeBook();
        }
        else
        {
            bloodSugar += food.sugar;
            checkBlood();
        }
    }
    private void GameOver()
    {
        Time.timeScale = 0f;
        GameOverScreen.SetActive(true);
    }

    public void administerInsulin(int amount)
    {
        bloodSugar -= amount;
        checkBlood();
    }
}
