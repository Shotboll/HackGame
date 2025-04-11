using UnityEngine;

public class PictureDialogueAnimator : MonoBehaviour
{
    public Animator picture;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        picture.SetBool("openPic", true);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        picture.SetBool("openPic", false);
    }
}
