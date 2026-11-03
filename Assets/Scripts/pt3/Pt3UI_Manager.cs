using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pt3UI_Manager : MonoBehaviour
{
    [SerializeField] private GameObject insulin;
    [SerializeField] private GameObject monitor;
    [SerializeField] private TextMeshProUGUI toggleText;
    [SerializeField] int dosage;
    [SerializeField] private TextMeshProUGUI dosageText;
    [SerializeField] private platformerController playerController;
    public bool recipeCanOpen = false;
    [SerializeField] private TextMeshProUGUI recipeText;

    [SerializeField] private GameObject recipeLog;

    [SerializeField] private GameObject recipe;
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

    public void itemToggle()
    {
        if (monitor.activeSelf)
        {
            insulin.SetActive(true);
            monitor.SetActive(false);
            toggleText.text = "Check Blood Sugar";
        }
        else
        {
            insulin.SetActive(false);
            monitor.SetActive(true);
            toggleText.text = "Administer Insulin";
        }
    }


    public void increment_dosage()
    {
        dosage = dosage < 4 ? dosage + 1 : 1;
        dosageText.text = dosage.ToString();
    }
    public void next_step()
    {
        playerController.administerInsulin(dosage * 10);
        itemToggle();
    }

    public void toggleRecipeBook()
    {
        recipeLog.SetActive(!recipeLog.activeSelf);
    }

    public void UpdateRecipeBook()
    {
        recipeText.text = "Avocado Lettuce Wrap";
        recipeCanOpen = true;
    }

    public void openRecipe()
    {
        if (recipeCanOpen)
        {
            recipe.SetActive(!recipe.activeSelf);
        }
    }
}
