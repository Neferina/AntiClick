using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	public float speed = 20f;
	public float maxSpeed = 2.5f;
	public bool ground;
	public float jumpForce = 3f;
	
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool jump;
	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Ground", ground);
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && ground){
			jump = true;
		}
	}
	
	void FixedUpdate(){
		float hSpeed = Input.GetAxis("Horizontal");
		rb2d.AddForce(Vector2.right * speed * hSpeed);
		
		float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
		rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);
		
		if (hSpeed > 0.1f) { transform.localRotation = Quaternion.Euler(0f, 0f, 0f);}
		if (hSpeed < -0.1f) { transform.localRotation = Quaternion.Euler(0f, 180f, 0f);}
		
		if(jump){
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			jump = false;
		}
		Debug.Log(rb2d.velocity.x);
	}
}
