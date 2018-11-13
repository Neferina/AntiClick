﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class andarenemigo : MonoBehaviour {
	public float speed;
	public Transform[] limites;
	private Rigidbody2D  rb2d;
	public bool derecha=true;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>(); 
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if(derecha)
			rb2d.MovePosition (rb2d.position + Vector2.right * speed * Time.fixedDeltaTime);
		else
			rb2d.MovePosition (rb2d.position + Vector2.left * speed * Time.fixedDeltaTime);
		
		if (transform.position.x >= limites [0].position.x) {
			derecha = false;
			transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
			

		if (transform.position.x <= limites [1].position.x) {
			derecha = true;
			transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
			
		
		/*
rb2d.AddForce (Vector2.right * speed);
			float limitedSpeed = Mathf.Clamp ( rb2d.velocity.x, -maxSpeed, maxSpeed);
			rb2d.velocity = new Vector2 (limitedSpeed,  rb2d.velocity.y);

		if (rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f) {
			speed = -speed;
			rb2d.velocity = new Vector2 (speed,  rb2d.velocity.y);*/
		//}
	}
}
