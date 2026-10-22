using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<string> sentences;
    public TextMeshProUGUI name;
    public TextMeshProUGUI dialogueText;
    public Image profile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        sentences = new List<string>();
    }

    public void StartDialogue1(Dialogue dialoguePav, Dialogue dialogueKid, Dialogue dialogueParent)
    {
        profile.sprite = dialoguePav.profile;
        name.text = dialoguePav.name;
        sentences.Clear();

        for (int i = 0; i < dialoguePav.sentences.Length; i++)
        {
            Enqueue(dialoguePav.sentences[i]);
            Enqueue(dialogueKid.sentences[i]);
            Debug.Log("setnence " + i + ": " + dialoguePav.sentences[i]);
        }
        DisplayNextSentence(dialoguePav, dialogueKid);

    }

    public void DisplayNextSentence(Dialogue dialogue1, Dialogue dialogue2)
    {
        swapProfile(dialogue1, dialogue2);
        if (sentences.Count <= 0)
        {
            Debug.Log("sentences is empty");
            EndDialogue();
            return;
        }
        // pops next sentence from queue into current sentence
        string curSentence = Dequeue();
        Debug.Log("true sentence: " + curSentence);
    }

    private void swapProfile(Dialogue dialogue1, Dialogue dialogue2)
    {

    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");
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
}
