using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuObj : MonoBehaviour
{
    private PlayerComponent player;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
}
