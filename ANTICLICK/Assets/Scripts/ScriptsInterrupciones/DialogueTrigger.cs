using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public Transform[] barrera;
    private bool[] tocados;
    public GameObject hero; //Este es click

    void Start()
    {
        tocados = new bool[barrera.Length];

        for (int i = 0; i < barrera.Length; i++)
            tocados[i] = false;
        
    }

    void FixedUpdate()
    {
        for (int i = 0; i < barrera.Length; i++)
        {
            if (hero.transform.position.x >= barrera[i].transform.position.x && tocados[i] == false)
            {
                if (i == 0)
                    FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                tocados[i] = true;
                FindObjectOfType<DialogueManager>().DisplayNextSentence();
            }
        }
    }
}
