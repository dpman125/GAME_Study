using System.Collections;
using UnityEngine;


public class draggables : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    float mousePosX;
    float mousePosY;
    Camera cam;
    Vector2 oldPosition;
    Vector2 velocity;
    Rigidbody2D rb;
    bool canDrag = true;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePosX = Input.mousePosition.x;
        mousePosY = Input.mousePosition.y;

    }

    void OnMouseOver()
    {
        Debug.Log(cam.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, cam.nearClipPlane + 1)));
    }
    private void OnMouseDown()
    {
        //rb.bodyType = RigidbodyType2D.Kinematic;
    }

    void OnMouseDrag()
    {
        //maps global mouse position to relative mouse position through the main camera
        // the cam.nearClipPlane+1 is to ensure z value is relative to the camera and not hard coded.
        //2d sprites are not visible when z=nearClipPlane, so the +1 is to set it after the clipping plane so it can be visible
        if (canDrag)
        {
            rb.position = cam.ScreenToWorldPoint(new Vector3(mousePosX, mousePosY, cam.nearClipPlane + 1));
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            dropObject();
        }

    }
    private void OnMouseUp()
    {
        dropObject();
        canDrag = true;
    }

    // stores old mouse position every .1 seconds to calculate velocity of object when "thrown"
    IEnumerator GetVelocity()
    {
        oldPosition = transform.position;
        yield return new WaitForSeconds(.2f);
        Vector2 newPosition = transform.position;
        velocity = new Vector2(newPosition.x - oldPosition.x, newPosition.y - oldPosition.y) * .2f;


    }
    void dropObject()
    {
        //rb.bodyType = RigidbodyType2D.Dynamic;
        StartCoroutine(GetVelocity());
        rb.linearVelocity = velocity;
        rb.position = oldPosition;
    }

    // disables drag if you hit a wall while dragging
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("CellWall") || collision.gameObject.CompareTag("CellLock"))
        {
            canDrag = false;
            Debug.Log("collided");
        }


    }


}
