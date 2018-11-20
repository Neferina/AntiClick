using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassaMove : MonoBehaviour {


    public float speed;
    public Rigidbody2D rb;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = Vector2.right * speed;


	}
}
