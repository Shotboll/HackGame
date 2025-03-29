using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    //public Dialogue dialogue;

    public void TriggerDialouge()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue();
    }
}
