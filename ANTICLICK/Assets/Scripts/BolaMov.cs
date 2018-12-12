using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BolaMov : MonoBehaviour {


    public GameObject hero;
    private Rigidbody2D rb;
    private Animator anim;
    private CircleCollider2D box;
    public bool triggeado = false;

    public float triggerTime = 0;

    public float speed;
    public bool moviendose;
    public bool muerto;
    public float tiempoMuerto;
    public float distance;
    public bool derecha;
    public bool darLaVuelta = false;

    private Vector2 target;
    private Vector3 scaler;

    public GameObject deadEffect;
    private Vector3 deadEffectOffset;
    public bool done = false;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<CircleCollider2D>();
        deadEffectOffset = new Vector3(0, 0.4f,0);
    }
	
	// Update is called once per frame
	void Update () {
        target = new Vector2(hero.transform.position.x, transform.position.y);

        if (triggeado)
            triggerTime += Time.deltaTime;

        if (triggerTime > 1f)
        {
            box.isTrigger = false;
            speed = 6f;
            moviendose = true;
        }
        if (triggerTime > 0.9f)
        {
            anim.SetBool("Movimiento", true);
            anim.SetBool("Apagado", false);
            anim.SetBool("Idle", false);
        }

        if (moviendose == true)
        {
            transform.position = Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);
            distance += Time.deltaTime;
            if (derecha)
            {
                if (darLaVuelta == false){
                    darLaVuelta = true;
                    Flip();
                }
            }
            else{
                if (darLaVuelta == true)
                    Flip();
                darLaVuelta = false;
            }

        }
        if (muerto == true)
        {
            box.enabled = false;
            triggerTime = 0;
            moviendose = false;
            speed = 0;
            tiempoMuerto += Time.deltaTime;
            if (done == true)
            {
                Instantiate(deadEffect, transform.position + deadEffectOffset, Quaternion.identity);
                done = false;
            }
            
            if (tiempoMuerto > 1f)
                Destroy(this.gameObject);
            
        }

        if (distance > 1f)
        {
            moviendose = false;
            distance = 0;
            triggeado = false;
            triggerTime = 0;
            speed = 0;
            box.isTrigger = true;
            anim.SetBool("Apagado", true);
            anim.SetBool("Movimiento", false);
            anim.SetBool("Aparecer", false);
            anim.SetBool("Idle", true);
            anim.SetBool("Muerto", false);
        }


        if (hero.transform.position.x > transform.position.x)
            derecha = true;
        else
            derecha = false;
	}


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && hero.transform.position.y > transform.position.y)
        {
            anim.SetBool("Muerto", true);
            anim.SetBool("Movimiento", false);
            anim.SetBool("Aparecer", false);
            anim.SetBool("Idle", false);
            muerto = true;
        }
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("xd");
            triggeado = true;
            anim.SetBool("Aparecer", true);
        }
            
    }

    void Flip()
    {
        scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }
}
