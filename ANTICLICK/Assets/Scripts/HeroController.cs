using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {
	public float speed = 10f;
    public float maxSpeed = 2.5f;
    public float maxDashSpeed = 8.0f;
    public bool ground;
    public bool right = true;
	public float jumpForce = 2f;

	public bool tocado = false; //detecta cuando es tocado por un enemigo (para cambiar el color y detectar damage)
	
	private Rigidbody2D rb2d;
	private Animator anim;
    private SpriteRenderer render;
	private bool jump;
    private bool dash;
    public int dashCoolDown;
	private int jumpDelay = 0; //Cuenta fotogramas antes de saltar para que coincida con la animación.
    public int dashDelay = 0; //Cuenta fotogramas mientras dura el dash para volver a aplicar el límite de velocidad.
    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Ground", ground);
		anim.SetFloat("VSpeed", rb2d.velocity.y);
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && ground){
			jump = true;
		}
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolDown==0 && !dash)
        {
            dash = true;
            dashDelay = 10;
            dashCoolDown = 100;
        }
        if (dash || dashDelay>0){dashDelay--;}
        if (jump && ground)
        {
		    jumpDelay++;
		}
		anim.SetBool("Jump", jump);
        anim.SetBool("Dash", dash);
        anim.SetInteger("DashDelay", dashDelay);
        if (dashCoolDown > 0) { dashCoolDown--; render.color = new Vector4(render.color.r, render.color.g, render.color.b, 0.7f); }
        else { render.color = new Vector4(render.color.r, render.color.g, render.color.b, 1.0f); }
    }
	
	void FixedUpdate(){
        float hSpeed = Input.GetAxisRaw("Horizontal");
        rb2d.AddForce(Vector2.right * speed * hSpeed);


		if (hSpeed > 0.1f) {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            right = true;
        }
		if (hSpeed < -0.1f) {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            right = false;
        }
		
		if(jumpDelay>9 && ground){
			rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
			jump = false;
			jumpDelay = 0;
		}

        if (dash)
        {
            if (right) { rb2d.AddForce(Vector2.right * jumpForce, ForceMode2D.Impulse); }
            else { rb2d.AddForce(Vector2.left * jumpForce, ForceMode2D.Impulse); }
            dash = false;
        }
        if (dashDelay == 0)
        {
            rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
        }
        else
        {
            rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxDashSpeed, maxDashSpeed), 0.0f);
        }

        if (Mathf.Abs(rb2d.velocity.y)>0.1){
			//Debug.Log(rb2d.velocity.y);
		}
	}
	
	
}
