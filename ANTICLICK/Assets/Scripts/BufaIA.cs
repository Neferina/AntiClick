using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BufaIA : MonoBehaviour {

    public Animator animator; //Es la variable que guarda el animator

    private float frame; //Mira el frame actual
    private float comp; //A lo que se le aplica el delta time

    private float startTime; //Con esto compruebo que animación debe reproducir

    private bool danyo; //Cuando hace mal al jugador
    private bool muerte; //Comprueba si ha muerto el personaje

    public int direccion; //Sirve para indicar si el bicho esta en el suelo o en el techo, debe ser siempre 1 o -1

    public GameObject hero;
    public enemyPassiveAttack herocontroller;
    private vidahero vida;

    // Use this for initialization
    void Start () {
        frame = 0.0f;
        animator.SetFloat("Change", 0.0f);

        herocontroller = GetComponent<enemyPassiveAttack>();

        startTime = 0.0f;
        danyo = false;
        muerte = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (muerte == false)
            actualizarFrame();
        else
            esperarMuerte();
        checkDamage();
	}

    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Tocado");
    }

    private void actualizarFrame() //Actualiza la variable para el animator y comprueba si tiene que cambiar de animación
    {
        frame++;

        comp = Time.deltaTime * frame - startTime; //Se usa para ver cuanto ha pasado desde el ultimo cambio de animacion

        if (comp >= 2.0f) //Si tiene que cambiar de animacion o no
        {
            startTime = Time.deltaTime * frame;
            comp = 0.0f;

            if (danyo == false) {
                danyo = true;
                GetComponent<PolygonCollider2D>().enabled = true;
                this.gameObject.tag = "Bufa";
            } else { 
                danyo = false;
                GetComponent<PolygonCollider2D>().enabled = false;
                this.gameObject.tag = "Enemy";
            }
        }
        
        animator.SetFloat("Change", comp);
    }

    private void checkDamage()
    {
        if (direccion == 1) { //Si esta en el suelo
            if (Mathf.Abs(hero.transform.position.x - this.transform.position.x) < 0.3f && Mathf.Abs(hero.transform.position.y - (this.transform.position.y + 0.5f)) < 0.2f && danyo == false)
            {
                muerte = true;
                animator.SetBool("Muerto", muerte);
                startTime = Time.deltaTime * frame;
                comp = 0.0f;
            }
        } else // Si esta en el techo
        {
            if (Mathf.Abs(hero.transform.position.x - this.transform.position.x) < 0.3f && (Mathf.Abs(hero.transform.position.y - (this.transform.position.y - 0.5f))) * direccion < -0.2f && danyo == false)
            {
                muerte = true;
                animator.SetBool("Muerto", muerte);
                startTime = Time.deltaTime * frame;
                comp = 0.0f;
            }
        }
    }

    private void esperarMuerte()
    {
        frame++;
        comp = Time.deltaTime * frame - startTime;

        if(comp >= 0.7f)
        {
            Destroy(this.gameObject);
        } else if (comp >= 0.3f)
        {
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
