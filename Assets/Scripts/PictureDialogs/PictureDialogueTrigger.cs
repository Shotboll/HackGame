using UnityEngine;

public class PictureDialogueTrigger : MonoBehaviour
{
    public void TriggerDialogue()
    {
        FindFirstObjectByType<PictureDialogueManager>().OpenPuzzle();
    }
}
