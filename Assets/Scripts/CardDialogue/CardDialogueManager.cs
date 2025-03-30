using UnityEngine;
using UnityEngine.SceneManagement;

public class CardDialogueManager : MonoBehaviour
{
    public Animator gachaAnim;
    public int levelToLoad;

    public void OpenGame()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void EndCraft()
    {
        gachaAnim.SetBool("openCard", false);
    }
}
