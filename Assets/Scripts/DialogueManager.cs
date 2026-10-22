using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    private Queue<string> sentences;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Start()
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {

        sentences.Clear();

        for (int i = 0; i < dialogue.sentences.Length; i++)
        {
            sentences.Enqueue(dialogue.sentences[i]);
            Debug.Log("setnence " + i + ": " + dialogue.sentences[i]);
        }
        DisplayNextSentence();

    }
    public void DisplayNextSentence()
    {
        if (sentences.Count > 0)
        {
            Debug.Log("sentences is empty");
            EndDialogue();
            return;
        }
        // pops next sentence from queue into current sentence
        string curSentence = sentences.Dequeue();
        Debug.Log("sentence: " + curSentence);
    }

    void EndDialogue()
    {
        Debug.Log("end of conversation");
    }
}
