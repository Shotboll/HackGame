using UnityEngine;

public class GachaDialogueAnimator : MonoBehaviour
{
    public Animator gachaAnim;
    public GachaDialogueManager dm;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        gachaAnim.SetBool("openRoll", true);
    }    
    public void OnTriggerExit2D(Collider2D collision)
    {
        gachaAnim.SetBool("openRoll", false);
        dm.EndCraft();
    }
}
