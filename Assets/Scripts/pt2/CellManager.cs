using TMPro;
using UnityEngine;

public class CellManager : MonoBehaviour
{

    public int need = 5;
    [SerializeField] private TextMeshPro scoreTxt;
    [SerializeField] private Pt2_GameManager gameManager;

    // Update is called once per frame
    void FixedUpdate()
    {
        scoreTxt.text = need.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("glucose") && need > 0)
        {
            //checks cell requirement
            need--;
            if (need == 0)
            {
                gameManager.CellCompleted();
            }
            //decreases blood sugar by 1 molucule (GameManager handles conversion)
            //removes 1 glucose and adds no insulin to update bloodstream
            gameManager.checkBlood(-1, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("glucose"))
        {
            //uncompletes if glucose is removed
            if (need == 0)
            {
                gameManager.CellUncompleted();
            }
            need++;
            //adds 1 glucose to bloodstream
            gameManager.checkBlood(1, 0);

        }

    }
}
