using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public Text txt;

    private Queue<string> sentences;

    public Animator animator;

	// Use this for initialization
	void Start () {
        sentences = new Queue<string>();
	}

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
    }

    public void DisplayNextSentence()
    {
        animator.SetBool("IsOpen", true);

        if (sentences.Count == 0)
        {
            return;
        }

        string sentence = sentences.Dequeue();

        txt.text = sentence;
    }

    public void FinishDialogue()
    {
        animator.SetBool("IsOpen", false);
    }
	
}
