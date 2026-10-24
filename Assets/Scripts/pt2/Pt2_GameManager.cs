using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pt2_GameManager : MonoBehaviour
{
    public CellManager[] cellList;

    public GameObject WinScreen;
    public GameObject HyperScreen;
    public TextMeshProUGUI BloodSugarText;
    public Image MonitorBackground;

    [SerializeField] int cellsCompleted = 0;
    [SerializeField] int looseGlucose = 0;
    [SerializeField] int looseInsulin = 0;
    [SerializeField] int bloodSugar = 100;
    bool paused = false;
    int warningRange = 180;
    int dangerRange = 240;
    int loseRange = 280;

    public void Start()
    {
        Time.timeScale = 1f;
        WinScreen.SetActive(false);
        HyperScreen.SetActive(false);
        cellList = GetComponents<CellManager>();
        Debug.Log(cellList.Length);
        BloodSugarText.text = bloodSugar.ToString();

    }



    // manages insulin in glucose levels, and is called externally with appropriate peramaters passed
    public void checkBlood(int addGlucose, int addInsulin)
    {
        looseGlucose += addGlucose;
        looseInsulin += addInsulin;
        bloodSugar += (addGlucose * 8); // 8 Mg/dL per glucose molecule, maintain less then 10 for healthy range
        BloodSugarText.text = bloodSugar.ToString();
        if (bloodSugar > loseRange)
        {
            GameOver();
        }
        else if (bloodSugar >= dangerRange)
        {
            MonitorBackground.color = Color.orangeRed;
        }
        else if (bloodSugar >= warningRange)
        {
            MonitorBackground.color = Color.yellow;
        }
        else
        {
            MonitorBackground.color = Color.limeGreen;
        }
    }
    // manages # of cells completed and overall win condition of the game
    public void CellCompleted()
    {
        cellsCompleted++;
        if (cellsCompleted == 12)
        {
            DisplayWinScreen();
        }
    }
    public void CellUncompleted()
    {
        cellsCompleted--;
    }

    public void DisplayWinScreen()
    {
        WinScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0f;

    }

    public void GameOver()
    {
        HyperScreen.SetActive(true);
        paused = true;
        Time.timeScale = 0f;

    }
}
