using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Animator craftAnim;
    public Animator startAnim;


    public void StartDialogue()
    {
        craftAnim.SetBool("StartOpen", true);
        startAnim.SetBool("StartOpen", false);
    }

    public void EndCraft()
    {
        craftAnim.SetBool("StartOpen", false);
    }
}
