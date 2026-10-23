using TMPro;
using UnityEngine;

public class CellManager : MonoBehaviour
{

    public int need = 5;
    [SerializeField] private TextMeshPro scoreTxt;
    void Start()
    {
        scoreTxt = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("glucose") || need > 0)
        {
            need--;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        need++;
    }
}
