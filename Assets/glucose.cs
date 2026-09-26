using UnityEngine;

public class glucose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("start");
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseOver()
    {
        Debug.Log("Mouse is over");
    }

    void OnMouseDrag()
    {
        Debug.Log("Mouse is Draging");
        Debug.Log(Input.mousePosition);
        transform.position = Input.mousePosition;
    }
}
