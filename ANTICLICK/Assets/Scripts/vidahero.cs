using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidahero : MonoBehaviour {
	Rigidbody2D rb2d;

	public float SaltoX, SaltoY;

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
	}
	

	void OnTriggerEnter2D (Collider2D other) {		
		if(other.tag == "Enemy")
		{
			GetComponent<SpriteRenderer> ().color = Color.red;
			rb2d.velocity = new Vector2 (SaltoX, SaltoY);

		}
	
		
	}
	void OnTriggerExit2D (Collider2D col) {		
		if(col.tag == "Enemy")
		{
			GetComponent<SpriteRenderer> ().color = Color.white;


		}

	}
}