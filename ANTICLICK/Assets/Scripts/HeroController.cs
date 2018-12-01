using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour {
	public float speed = 14f;
    public float maxSpeed = 2.5f;
    public float maxDashSpeed = 8.0f;
    public bool ground;
    public bool right = true;
	public float jumpForce = 11f;
    public float moveInput;
    public float hSpeed;
    public float distanciaGameOver;

    private vidahero Vidas;
    public GameObject masa;

    public bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;

    public bool tocado = false; //detecta cuando es tocado por un enemigo (para cambiar el color y detectar damage)
	
	private Rigidbody2D rb2d;
	private Animator anim;
    private SpriteRenderer render;
	private bool jump;
    private bool frenar;
    private bool dash;
    public bool teclasalto;
    public float dashCoolDown;
	private float jumpDelay = 0; //Cuenta fotogramas antes de saltar para que coincida con la animación.
    public float dashDelay = 0; //Cuenta fotogramas mientras dura el dash para volver a aplicar el límite de velocidad.


    public GameObject DashEffect;
    private Vector3 DashOffset;


    private GameManager gm;

    void Start () {
        Vidas = GetComponent<vidahero>();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        transform.position = gm.lastCheckPointPos;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        DashOffset = new Vector3(0, 0.2f, 0);
    }
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
		anim.SetBool("Ground", isGrounded);
		anim.SetFloat("VSpeed", rb2d.velocity.y);
		
		if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded){
			jump = true;
            teclasalto = true;
		}
        
        if (Input.GetKeyDown(KeyCode.Space) && dashCoolDown==0 && !dash)
        {
            Instantiate(DashEffect, transform.position + DashOffset, Quaternion.identity);
            dash = true;
            dashDelay = 10;
            dashCoolDown = 100;
        }
        if (dash || dashDelay>0){dashDelay--;}
        if (jump && isGrounded)
        {
            jumpDelay +=Time.deltaTime;
		}
		anim.SetBool("Jump", jump);
        anim.SetBool("Dash", dash);
        anim.SetFloat("DashDelay", dashDelay);
        if (dashCoolDown > 0) { dashCoolDown--; render.color = new Vector4(render.color.r, render.color.g, render.color.b, 0.7f); }
        else { render.color = new Vector4(render.color.r, render.color.g, render.color.b, 1.0f); }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            frenar = true;
        }

    }
	
	void FixedUpdate(){

        

        hSpeed = Input.GetAxisRaw("Horizontal");


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);   

		if (hSpeed > 0.1f) {
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
            right = true;
        }
		if (hSpeed < -0.1f) {
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
            right = false;
        }
		
		if(jumpDelay>0.08 && isGrounded){
            rb2d.velocity = Vector2.up * jumpForce;
			jump = false;
			jumpDelay = 0;  
		}
        if ((frenar || !Input.GetKey(KeyCode.UpArrow)) && rb2d.velocity.y > -0.5)
        {
            rb2d.velocity += Vector2.down * rb2d.velocity.y/20;
            frenar = false;
        }
        if (dash)
        {
            if (right) { rb2d.AddForce(Vector2.right * jumpForce*1.5f, ForceMode2D.Impulse); }
            else { rb2d.AddForce(Vector2.left * jumpForce*1.5f, ForceMode2D.Impulse); }
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

        if (SceneManager.GetActiveScene().name == "Pradera")
            distanciaGameOver = -13.0f;
        if (SceneManager.GetActiveScene().name == "Cueva")
            distanciaGameOver = -24.0f;
        if (SceneManager.GetActiveScene().name == "Nieve")
            distanciaGameOver = -40.0f;
        if (SceneManager.GetActiveScene().name == "Castillo")
            distanciaGameOver = -8.0f;

        if (rb2d.position.y < distanciaGameOver) //Cuando cae por un preci
        {
            Vidas.cantidadVidas--;
            transform.position = gm.lastCheckPointPos;
            masa.transform.position = new Vector2(transform.position.x - 20, transform.position.y);
        }

        
	}
	
}
