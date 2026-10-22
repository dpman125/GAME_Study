using UnityEngine;

public class DialogueEditor : MonoBehaviour
{
    public Dialogue dialogue;

    public void TriggerDialogue()
    {
        Debug.Log("dialogue initial:" + dialogue.sentences[0]);
        DialogueManager dialogueManager = FindFirstObjectByType<DialogueManager>();
        dialogueManager.StartDialogue(dialogue);
    }
}
