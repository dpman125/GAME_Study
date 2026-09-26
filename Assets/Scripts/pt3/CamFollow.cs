using UnityEngine;

public class CamFollow : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    private Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = playerTransform.position + offset;
    }
}
