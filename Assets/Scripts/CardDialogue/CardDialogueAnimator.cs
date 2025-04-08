using UnityEngine;

public class CardDialogueAnimator : MonoBehaviour
{
    public Animator cardAnim;
    public CardDialogueManager dm;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        cardAnim.SetBool("openCard", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        cardAnim.SetBool("openCard", false);
        dm.EndCraft();
    }
}
