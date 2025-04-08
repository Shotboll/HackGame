using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public void TriggerDialouge()
    {
        FindFirstObjectByType<DialogueManager>().StartDialogue();
    }
}
