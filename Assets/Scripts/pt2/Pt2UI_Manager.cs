using UnityEngine;
using UnityEngine.SceneManagement;

public class Pt2UI_Manager : MonoBehaviour
{

    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
    }
    public void play()
    {
        SceneManager.LoadScene("Insulin");
    }
    public void replay()
    {
        SceneManager.LoadScene("InsulinUI");
    }

    public void continueOn()
    {
        SceneManager.LoadScene("CutScene3");
    }
    public void LearnMore()
    {
        SceneManager.LoadScene("Info");
    }
}
