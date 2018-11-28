using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {


    private GameManager gm;
    public Sprite verde;
    private SpriteRenderer sr;

    // Use this for initialization
    void Start () {
        sr = GetComponent<SpriteRenderer>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
	}

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sr.sprite = verde;
            gm.lastCheckPointPos = transform.position;
        }
    }
}
