using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<string> sentences;
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI dialogueText;
    public Image profile;

    public Dialogue dialoguePavG, dialogueKidG, dialogueParentG;

    public int sceneFlag = 0;

    public GameObject mainMenu, fingerPrick;

    private bool isFingerPricked = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        if (sceneFlag == 1)
        {
            StartDialogue1(dialoguePavG, dialogueKidG, dialogueParentG);
        }
        sentences = new List<string>();
    }
    public void Update()
    {
        if (isFingerPricked)
        {
            fingerPrick.transform.localScale = new Vector3(5f * Time.deltaTime, 5f * Time.deltaTime, 0f);

        }
    }

    public void StartDialogue1(Dialogue dialoguePav, Dialogue dialogueKid, Dialogue dialogueParent)
    {
        profile.sprite = dialogueKid.profile;
        nameLabel.text = dialogueKid.name;
        sentences.Clear();
        // if first scene, remove main menu
        // queue up Pav and Kid Dialouge for pt 1
        // new parts for dialogue will be added later
        if (sceneFlag == 0)
        {
            mainMenu.SetActive(false);
            for (int i = 0; i < dialoguePav.sentences.Length; i++)
            {
                Enqueue(dialoguePav.sentences[i]);
                Enqueue(dialogueKid.sentences[i]);
                Debug.Log("setnence " + i + ": " + dialoguePav.sentences[i]);
            }
            dialoguePavG = dialoguePav;
            dialogueKidG = dialogueKid;
            DisplayNextSentence();
        }
        else if (sceneFlag == 1)
        {
            for (int i = 0; i < dialoguePav.sentences.Length; i++)
            {
                Enqueue(dialoguePav.sentences[i]);
                Enqueue(dialogueKid.sentences[i]);
                Debug.Log("setnence " + i + ": " + dialoguePav.sentences[i]);
            }
            dialoguePavG = dialoguePav;
            dialogueKidG = dialogueKid;
            DisplayNextSentence();
        }

    }


    public void DisplayNextSentence()
    {
        swapProfile(dialoguePavG, dialogueKidG);
        if (sentences.Count <= 0)
        {
            Debug.Log("sentences is empty");
            EndDialogue();
            return;
        }
        // pops next sentence from queue into current sentence
        string curSentence = Dequeue();
        dialogueText.text = curSentence;
        Debug.Log("true sentence: " + curSentence);
    }

    private void swapProfile(Dialogue dialogue1, Dialogue dialogue2)
    {
        if (nameLabel.text == dialogue1.name)
        {
            nameLabel.text = dialogue2.name;
            profile.sprite = dialogue2.profile;
        }
        else if (nameLabel.text == dialogue2.name)
        {
            nameLabel.text = dialogue1.name;
            profile.sprite = dialogue1.profile;
        }
        else
        {
            Debug.LogError("swap profile exception. name comparison was invalid");
        }
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");

        if (sceneFlag == 0)
        {
            StartCoroutine(Transition1());
        }
        else if (sceneFlag == 1)
        {
            StartCoroutine(Transition2());
        }
    }
    public void Enqueue(string sentence)
    {
        sentences.Add(sentence);
    }
    public string Dequeue()
    {
        string temp = sentences[0];
        sentences.RemoveAt(0);
        return temp;
    }
    IEnumerator<UnityEngine.WaitForSeconds> Transition1()
    {
        fingerPrick.SetActive(true);
        yield return new WaitForSeconds(4f);

        SceneManager.LoadScene("BetaCellUI");
    }
    IEnumerator<UnityEngine.WaitForSeconds> Transition2()
    {
        fingerPrick.SetActive(true);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("InsulinUI");
    }

}
