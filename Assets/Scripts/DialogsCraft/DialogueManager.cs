using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //public Text dialogueText;
    //public Text nameText;

    public Animator craftAnim;
    public Animator startAnim;

    //private Queue<string> sentences;

    //private void Start()
    //{
    //    sentences = new Queue<string>();
    //}

    public void StartDialogue()
    {
        craftAnim.SetBool("StartOpen", true);
        startAnim.SetBool("StartOpen", false);

        //sentences.Clear();

        //foreach(string sentence in dialogue.sentences)
        //{
        //    sentences.Enqueue(sentence);
        //}

    }

    public void EndCraft()
    {
        craftAnim.SetBool("StartOpen", false);
    }
}
