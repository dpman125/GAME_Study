using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pt2UI_Manager : MonoBehaviour
{

    private float currentTime;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI timerTextLive;
    private playerController pc;
    public bool ignoreTimer = false;

    void Start()
    {
        currentTime = 0;


    }

    // Update is called once per frame
    void Update()
    {
    }
    public void replay()
    {
        SceneManager.LoadScene("Insulin");
    }

    public void continueOn()
    {
        SceneManager.LoadScene("CutScene3");
    }
}
