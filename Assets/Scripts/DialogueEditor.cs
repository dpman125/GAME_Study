using UnityEngine;

public class DialogueEditor : MonoBehaviour
{
    public Dialogue dialoguePav;
    public Dialogue dialogueKid;
    public Dialogue dialogueParent;
    private DialogueManager dm;

    private void Start()
    {
        dm = GetComponent<DialogueManager>();
        if (dm.sceneFlag == 1)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        DialogueManager dialogueManager = FindFirstObjectByType<DialogueManager>();
        dialogueManager.StartDialogue1(dialoguePav, dialogueKid, dialogueParent);
    }
}
