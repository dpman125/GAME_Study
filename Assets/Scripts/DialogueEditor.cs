using UnityEngine;

public class DialogueEditor : MonoBehaviour
{
    public Dialogue dialoguePav;
    public Dialogue dialogueKid;
    public Dialogue dialogueParent;

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindFirstObjectByType<DialogueManager>();
        dialogueManager.StartDialogue1(dialoguePav, dialogueKid, dialogueParent);
    }
}
