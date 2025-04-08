using UnityEngine;

public class GachaDialogueTrigger : MonoBehaviour
{
    public void TriggerDialouge()
    {
        FindFirstObjectByType<GachaDialogueManager>().Roll();
    }
}
