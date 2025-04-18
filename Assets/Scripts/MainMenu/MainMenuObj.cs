using System.Collections;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuObj : MonoBehaviour
{
    private PlayerComponent player;

    public GameObject startComics;

    public void PlayGame()
    {
        if(File.Exists(Application.persistentDataPath + "/player.save"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }

    public void NewGame()
    {
        Transform parent = transform.parent;

        startComics = parent.transform.parent.transform.parent.Find("startComics").gameObject;

        File.Delete(Application.persistentDataPath + "/player.save");
        startComics.SetActive(true);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(15.4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
