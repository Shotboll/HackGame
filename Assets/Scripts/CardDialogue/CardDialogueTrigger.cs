using UnityEngine;

public class CardDialogueTrigger : MonoBehaviour
{
    public void TriggerDialouge()
    {
        FindFirstObjectByType<CardDialogueManager>().OpenGame();
    }
}
