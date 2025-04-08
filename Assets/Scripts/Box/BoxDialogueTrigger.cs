using UnityEngine;

public class BoxDialogueTrigger : MonoBehaviour
{
    public void TriggerDialouge()
    {
        FindFirstObjectByType<BoxDialogueManager>().OpenBox();
    }
}
