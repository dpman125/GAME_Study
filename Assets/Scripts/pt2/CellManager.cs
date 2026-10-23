using TMPro;
using UnityEngine;

public class CellManager : MonoBehaviour
{

    public int need = 5;
    [SerializeField] private TextMeshPro scoreTxt;
    [SerializeField] private Pt2_GameManager gameManager;
    void Start()
    {
        gameManager = GetComponent<Pt2_GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreTxt.text = need.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("glucose") && need > 0)
        {
            need--;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        need++;
    }
}
