using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoScript : MonoBehaviour {

    private BoxCollider2D box;
    private Animator anim;
    public GameObject coinEffect;
    private bool hecho = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
	}
	

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if (hecho == false)
            {
                Instantiate(coinEffect, transform.position, Quaternion.identity);
                hecho = true;
            }
            box.enabled=false;
            anim.SetBool("Golpeado", true);
        }
    }


    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            anim.SetBool("Golpeado", false);
        }
    }
}
