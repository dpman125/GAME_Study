using PinePie.SimpleJoystick;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{

    public Vector2 moveDirection;
    public float speed = 4f;
    public InputValue horizontalMove;
    public InputActionReference move;
    private JoystickController joystickController;
    Rigidbody2D rb;
    public int health = 8;

    public bool paused = false;

    public GameObject GameOverScreen;

    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();
        GameOverScreen.SetActive(false);
        JoystickController[] joysticks = FindObjectsByType<JoystickController>(FindObjectsSortMode.None);
        foreach (var joystick in joysticks)
        {
            if (joystick.name == "Joystick") joystickController = joystick;
            else Debug.LogWarning("Joystick not found");

        }
    }
    // Update is called once per frame
    void Update()
    {

        moveDirection = move.action.ReadValue<Vector2>();

        rb.AddForce(new Vector3(moveDirection.x, moveDirection.y, 0f) * speed * Time.deltaTime, ForceMode2D.Impulse);
        rb.AddForce((Vector3)joystickController.InputDirection * speed * Time.deltaTime, ForceMode2D.Impulse);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (health <= 0)
            {
                GameOverScreen.SetActive(true);
                paused = true;
                Time.timeScale = 0f;
            }
            Debug.Log("Took Hit");
            transform.localScale /= 1.3f;
            health--;

        }
    }
}

