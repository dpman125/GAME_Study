using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI bloodSugar;

    public platformerController playerScript;
    public GameObject pauseScreen;
    public bool isPaused;

    private void Start()
    {
        isPaused = false;
        pauseScreen.SetActive(isPaused);
    }
    private void FixedUpdate()
    {
        bloodSugar.text = playerScript.bloodSugar.ToString() + " mg/dL";
    }

    public void pause()
    {
        // toggle isPaused
        isPaused = isPaused ? false : true;
        pauseScreen.SetActive(isPaused);
    }
}
