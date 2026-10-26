using UnityEngine;
using UnityEngine.SceneManagement;

public class Pt3UI_Manager : MonoBehaviour
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
        SceneManager.LoadScene("platformer");
    }
    public void replay()
    {
        SceneManager.LoadScene("platformerUI");
    }

    public void continueOn()
    {
        SceneManager.LoadScene("CutScene1");
    }
    public void LearnMore()
    {
        SceneManager.LoadScene("Info");
    }
}
