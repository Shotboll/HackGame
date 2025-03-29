using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public int fullElement;
    public static int myElement;
    public GameObject myPanel;
    public GameObject myPuzzle;
    public Animator anim;

    void Start()
    {
        fullElement = myPuzzle.transform.childCount;
    }

    private void Update()
    {
        if(fullElement == myElement)
        {
            myPanel.SetActive(false);
            anim.SetBool("openWindow", true);
        }
    }

    public static void AddElement()
    {
        myElement++;
    }
}