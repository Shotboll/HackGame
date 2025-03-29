using UnityEngine;

public class DialogueAnimator : MonoBehaviour
{
    public Animator craftAnim;
    public DialogueManager dm;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        craftAnim.SetBool("StartOpen", true);
    }    
    public void OnTriggerExit2D(Collider2D collision)
    {
        craftAnim.SetBool("StartOpen", false);
        dm.EndCraft();
    }
}
