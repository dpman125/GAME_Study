using UnityEngine;

public class changeScene : MonoBehaviour
{
    public float transformationValue;
    public bool exited;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            Camera cam = Camera.main;
            cam.transform.position += new Vector3(transformationValue, 0f, 0f);
            transformationValue *= -1;
        }
    }

}
