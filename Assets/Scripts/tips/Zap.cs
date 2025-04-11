using UnityEngine;

public class Zap : MonoBehaviour
{
    public Animator zpAnim;
    public Animator closeNote;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        zpAnim.SetBool("openNote", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        zpAnim.SetBool("openNote", false);
        closeNote.SetBool("zpOpen", false);
    }
}
