using UnityEngine;

public class End : MonoBehaviour
{
    public Animator endAnim;
    public void ShowEnd()
    {
        endAnim.SetBool("endOpen", true);
    }
}
