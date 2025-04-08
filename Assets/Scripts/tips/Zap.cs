using UnityEngine;

public class Zap : MonoBehaviour
{
    public Animator zpAnim;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        zpAnim.SetBool("zpOpen", true);
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        zpAnim.SetBool("zpOpen", false);
    }
}
