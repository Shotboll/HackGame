using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int fullElement;
    public static int myElement;
    public GameObject myPanel;
    public GameObject myPuzzle;
    private PlayerComponent player;

    void Start()
    {
        fullElement = myPuzzle.transform.childCount;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerComponent>();
    }

    private void Update()
    {
        if(fullElement == myElement)
        {
            OnRestartClick();
            player.colTickects += 5;
            myPanel.SetActive(false);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }

    // В вашем скрипте для кнопки рестарта
    public void OnRestartClick()
    {
        MovingPuzzleUI[] allPieces = FindObjectsOfType<MovingPuzzleUI>();

        foreach (var piece in allPieces)
        {
            piece.ResetPiece();
        }

        PuzzleManager.myElement = 0;
    }

}