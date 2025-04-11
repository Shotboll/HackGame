using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class PictureDialogueManager : MonoBehaviour
{

    public GameObject pic;

    public void OpenPuzzle()
    {
        pic.SetActive(true);
    }
}
