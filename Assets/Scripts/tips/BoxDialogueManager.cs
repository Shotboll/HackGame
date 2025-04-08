using UnityEngine;
using UnityEngine.SceneManagement;

public class BoxDialogueManager : MonoBehaviour
{
    public Animator boxAnim;
    public Animator boxInsideAnim;

    public void OpenBox()
    {
        boxInsideAnim.SetBool("insideOpen", true);
    }

    public void EndCraft()
    {
        boxAnim.SetBool("boxButton", false);
        boxInsideAnim.SetBool("insideOpen", false);
    }
}
