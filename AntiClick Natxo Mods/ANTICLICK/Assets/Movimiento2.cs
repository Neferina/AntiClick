using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour {

    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    public float dashSpeed;
    public float dashCD;
    public float dashCDMax;

    public int jumps;

    public ParticleSystem dashEffect;

    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0) {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (Input.GetKeyDown(KeyCode.Space) && dashCD == 0)
        {
            if (facingRight == true)
            {
                rb.velocity = Vector2.right * dashSpeed;
                dashEffect.Play();
                dashCD = dashCDMax;
            }else if (facingRight == false)
            {
                rb.velocity = Vector2.left * dashSpeed;
                dashEffect.Play();
                dashCD = dashCDMax;
            }

        }


    }

    void Update()
    {
        if (dashCD > 0)
        {
            dashCD--;
        }

        if (isGrounded == true)
        {
            jumps = 1;
        }
    
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            jumps--;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

}
