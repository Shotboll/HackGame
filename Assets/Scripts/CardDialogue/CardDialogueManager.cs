using UnityEngine;
using UnityEngine.SceneManagement;

public class CardDialogueManager : MonoBehaviour
{
    public Animator cardAnim;
    public Animator gameAnim;
    public int levelToLoad;

    public void OpenGame()
    {

        gameAnim.SetBool("gameOpen", true);
    }

    public void EndCraft()
    {
        cardAnim.SetBool("openCard", false);
        gameAnim.SetBool("gameOpen", false);
    }
}
