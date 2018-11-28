using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatoScript : MonoBehaviour {


    private Animator anim;
    public GameObject coinEffect;
    private bool hecho = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
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
