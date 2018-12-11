using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionMovement : MonoBehaviour {

	public float speed;
	public Transform[] limites;
	private Rigidbody2D  rb2d;
    private Animator anim;
    public bool derecha=true;
    public GameObject hero;
    public float morir = -1f;
    public GameObject blood;
    public string type;

    private float cooldown; //Cooldown de la habilidad de cada bicho
    private bool alterMode; //Marca el modo alternativo de los enemigos (Pararse y lanzar huesos, cargar, etc; todo aquello que no sea el comportamiento normal)
    private bool resetCD = true; //para resetear el CD del hueso
    public GameObject hueso;
    public GameObject huesoDerecho;
    private PolygonCollider2D box;
    public float distanceDead;




    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponent<PolygonCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Morir", morir);
        anim.SetBool("Alter", alterMode);
        if (derecha)
        {
            rb2d.MovePosition(rb2d.position + Vector2.right * speed * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else
        {
            rb2d.MovePosition(rb2d.position + Vector2.left * speed * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (transform.position.x > limites[0].position.x)
        {
            derecha = false;
            if(type == "Caballero" && alterMode) { Frenar(); }
            //transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
        }


        if (transform.position.x < limites[1].position.x)
        {
            derecha = true;
            if (type == "Caballero" && alterMode) { Frenar(); }
            //transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        }



        if (morir > 0)
        {
            box.enabled = false;
            morir += Time.deltaTime;
        }
        if (morir > 1.6f)
        {
            Destroy(this.gameObject);
        }

        if (type == "Esqueleto") //COSAS QUE SÓLO HACE SI ES UN ESQUELETO
        {
            if (Mathf.Abs(hero.transform.position.x - transform.position.x) < 3)
            {
                speed = 0;
                alterMode = true;
            }
            if (Mathf.Abs(hero.transform.position.x - transform.position.x) > 4)
            {
                speed = 2;
                alterMode = false;
            }

            if (alterMode)
            {
                if (resetCD)
                {
                    cooldown = 0;
                    resetCD = false;
                }
                cooldown -= Time.deltaTime;
                if (hero.transform.position.x > transform.position.x && !derecha)
                {
                    derecha = true;
                }
                else if (hero.transform.position.x <= transform.position.x && derecha)
                {
                    derecha = false;
                }
                if (cooldown < 0)
                {
                    Disparar();
                }
            }
            else
            {
                resetCD = true;
            }
        }

        if (type == "Caballero") //COSAS QUE SÓLO HACE SI ES UN CABALLERO
        {
            if (hero.transform.position.x < limites[0].position.x && hero.transform.position.x > limites[1].position.x && cooldown<=0)
            {
                alterMode = true;
            }
            if(alterMode)
            {
                speed += 0.01f + speed * 0.002f;
                if (speed < 1.6)
                {
                    if (hero.transform.position.x > transform.position.x && !derecha)
                    {
                        derecha = true;
                    }
                    else if (hero.transform.position.x <= transform.position.x && derecha)
                    {
                        derecha = false;
                    }
                }
            }
            else { speed = 0.8f; cooldown -= Time.deltaTime; }


        }

    }
    void Disparar()
    {
        if (derecha)
        {
            Instantiate(huesoDerecho, transform.position, transform.localRotation);
        }
        else
        {
            Instantiate(hueso, transform.position, transform.localRotation);
        }
        cooldown = 1.9f;
    }

    void Frenar()
    {
        alterMode = false;
        cooldown = 2.0f;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Mathf.Abs(hero.transform.position.y - transform.position.y) < distanceDead) //Saltar encima
            {

                if (morir == -1f)
                {
                    Instantiate(blood, transform.position, Quaternion.identity);

                }
                morir = 1f;
                speed = 0;
            }
        }

    }
}
