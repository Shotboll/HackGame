using UnityEngine;

public class openNote : MonoBehaviour
{
    public Animator note;

    public void OpenNote()
    {
        note.SetBool("zpOpen", true);
    }
}
