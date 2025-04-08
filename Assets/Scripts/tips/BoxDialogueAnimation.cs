using UnityEngine;

public class BoxDialogueAnimation : MonoBehaviour
{
    public Animator boxAnim;
    public BoxDialogueManager dm;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        boxAnim.SetBool("boxButton", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        boxAnim.SetBool("boxButton", false);
        dm.EndCraft();
    }
}
