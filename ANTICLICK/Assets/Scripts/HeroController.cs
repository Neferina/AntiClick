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

    //Anteriormente en VIDAHERO.CS
    public float SaltoX, SaltoY;
    private bool salto = true;
    public float DeathDelay = 0.8f;
    bool invencible = false;

    public vidahero Vidas;
	private playsound playSound;
    public GameObject masa;
    public bool dead;

    public bool isGrounded;
    public Transform groundCheck;
    public float CheckRadius;
    public LayerMask whatIsGround;

    public bool tocado = false; //detecta cuando es tocado por un enemigo (para cambiar el color y detectar damage)
	
	private Rigidbody2D rb2d;
	private Animator anim;
    private Animator gameoverAnim;
    private SpriteRenderer render;
	private bool jump;
    private bool frenar;
    private bool dash;
    public float dashCoolDown;
	private float jumpDelay = 0f; //Cuenta tiempo antes de saltar para que coincida con la animación.
    public float dashDelay = 0f; //Cuenta tiempo mientras dura el dash para volver a aplicar el límite de velocidad.


    public GameObject DashEffect;
    private Vector3 DashOffset;


    private GameManager gm;

    void Awake () {
        gameoverAnim = GameObject.Find("Main Camera").GetComponent<Animator>();
        Vidas = GetComponent<vidahero>();
		playSound = GetComponent<playsound> ();
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
        //transform.position = gm.lastCheckPointPos;
		rb2d = GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
        render = GetComponent<SpriteRenderer>();
        DashOffset = new Vector3(0, 0.2f, 0);
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        //CONTROL DE ANIMACIONES
        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Ground", isGrounded);
        anim.SetFloat("VSpeed", rb2d.velocity.y);
        anim.SetBool("Dead", dead);
        anim.SetBool("Jump", jump);
        anim.SetBool("Dash", dash);
        anim.SetFloat("DelayDash", dashDelay);

        if (!dead && !tocado)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                jump = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) && dashCoolDown == 0 && !dash)
            {
                Instantiate(DashEffect, transform.position + DashOffset, Quaternion.identity);
                dash = true;
                dashDelay = 0.2f;
                dashCoolDown = 100;
				playSound.PlayDash ();
            }
            if (dash || dashDelay > 0) { dashDelay-= Time.deltaTime; }
            if (jump && isGrounded)
            {
                jumpDelay += Time.deltaTime;
            }

            if (dashCoolDown > 0) { dashCoolDown--; render.color = new Vector4(render.color.r, render.color.g, render.color.b, 0.7f); }
            else { render.color = new Vector4(render.color.r, render.color.g, render.color.b, 1.0f); }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                frenar = true;
            }
        }

        //Cambiar TOCADO e INVENCIBLE a false al caer al suelo tras un KNOCKBACK
        if (rb2d.velocity.y < 0.1 && !salto && isGrounded)
        {
            salto = true;
            tocado = false;
            invencible = false;
            Debug.Log("RECUPERACIÓN");
        }

        //MORIRSE
        if (Vidas.cantidadVidas < 1)
        {
            dead = true;
            gameoverAnim.SetTrigger("gameover");
            GetComponent<SpriteRenderer>().color = Color.white;
            DeathDelay -= Time.deltaTime;;
        }

        if (DeathDelay <= 0)
        {
            Debug.Log("Game Over");
            StartCoroutine(Reiniciar());
            dead = false;
        }
    }


    void FixedUpdate() {

        if (dead)
        {
            speed = 0f;
            hSpeed = 0.0f;
            rb2d.Sleep();
        }
        else if (!tocado)
        {
            hSpeed = Input.GetAxisRaw("Horizontal");
        }


        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);
        if (!tocado)
        {
            rb2d.velocity = new Vector2(hSpeed * speed, rb2d.velocity.y);
            GetComponent<SpriteRenderer>().color = Color.white; //restablece o mantiene el color normal de CLICK

            if (hSpeed > 0.1f) {
                transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
                right = true;
            }
            if (hSpeed < -0.1f) {
                transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
                right = false;
            }

            if (jumpDelay > 0.08 && isGrounded) {
                rb2d.velocity = Vector2.up * jumpForce;
                jump = false;
                jumpDelay = 0;
            }
            if ((frenar || !Input.GetKey(KeyCode.UpArrow)) && rb2d.velocity.y > -0.5)
            {
                rb2d.velocity += Vector2.down * rb2d.velocity.y / 20;
                frenar = false;
            }
            if (dash)
            {
                if (right) { rb2d.AddForce(Vector2.right * jumpForce * 1.5f, ForceMode2D.Impulse); }
                else { rb2d.AddForce(Vector2.left * jumpForce * 1.5f, ForceMode2D.Impulse); }
                dash = false;
            }
            if (dashDelay <= 0)
            {
            rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed), rb2d.velocity.y);
            }
         else
            {
                rb2d.velocity = new Vector2(Mathf.Clamp(rb2d.velocity.x, -maxDashSpeed, maxDashSpeed), 0.0f);
            }
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


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platMovil")
        {
            this.transform.parent = collision.transform;
        }

        if (tocado && !dead)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            if (!invencible)
            {
                Vidas.cantidadVidas--;
                invencible = true;
            }

            if (right && salto)
            {
                rb2d.velocity = new Vector2(-SaltoX, SaltoY);
                salto = false;

            }
            else if(!right && salto)
            {
                rb2d.velocity = new Vector2(SaltoX, SaltoY);
                salto = false;
            }
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platMovil")
        {
            this.transform.parent = null;
        }
    }

    IEnumerator Reiniciar()
    {
        yield return new WaitForSeconds(2.0f);
        FindObjectOfType<GameManager>().EndGame();
    }
}
