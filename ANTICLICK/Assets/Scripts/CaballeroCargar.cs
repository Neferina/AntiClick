using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaballeroCargar : MonoBehaviour
{


    public float speed;
    public float speedCargar;
    public float distancia;
    public float distanciaMaxima;
    public float distanciaCargar;
    public float speedCargarInicial;
    public HeroController hero;
    public bool cargar;
    public bool derecha;
    public float morir;
    public bool muerto = false;

    public bool CargaHecha = false;
    private Animator anim;

    private Rigidbody2D rb;

    public GameObject pd;
    public GameObject pi;


    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        distancia = 0;
    }


    void FixedUpdate()
    {

        if (distanciaCargar > 75)
        {
            cargar = false;
        }

        if (muerto == false)
        {
            if (derecha == true)
            {
                if (cargar == true && CargaHecha == false)
                {
                    if (speedCargar < 3f)
                        speedCargar += 0.05f;
                    distanciaCargar++;
                    distancia++;
                    if (hero.transform.position.x > transform.position.x && transform.position.y > hero.transform.position.y)
                    {
                        anim.SetTrigger("isCharging");
                        anim.SetBool("CaminarDrch", true);
                        rb.MovePosition(rb.position + Vector2.right * speedCargar * Time.fixedDeltaTime);
                        if (distanciaCargar > 70)
                            CargaHecha = true;
                    }
                }
                else
                {
                    anim.SetBool("CaminarDrch", true);
                    rb.MovePosition(rb.position + Vector2.right * speed * Time.fixedDeltaTime);
                    distancia++;
                }

            }
            else
            {
                if (cargar == true && CargaHecha == false)
                {
                    if (speedCargar < 3f)
                        speedCargar += 0.05f;
                    distanciaCargar++;
                    distancia++;
                    if (hero.transform.position.x < transform.position.x && transform.position.y > hero.transform.position.y)
                    {
                        anim.SetTrigger("isCharging");
                        anim.SetBool("CaminarDrch", false);
                        rb.MovePosition(rb.position + Vector2.left * speedCargar * Time.fixedDeltaTime);
                        if (distanciaCargar > 70)
                            CargaHecha = true;
                    }
                }
                else
                {
                    anim.SetBool("CaminarDrch", false);
                    rb.MovePosition(rb.position + Vector2.left * speed * Time.fixedDeltaTime);
                    distancia++;
                }

            }


            if (distancia > 300)
            {
                speedCargar = speedCargarInicial;
                distancia = 0;
                derecha = !derecha;
                CargaHecha = false;
            }
        }
        


        if (hero.transform.position.x > pi.transform.position.x && hero.transform.position.x < pd.transform.position.x)
        {
            
            
            if (derecha == true && transform.position.x < hero.transform.position.x)
            {
                cargar = true;
            }
            else if (derecha == false && transform.position.x > hero.transform.position.x)
            {
                cargar = true;
            }

        }


        else
        {
            if (distanciaCargar > 0 && distanciaCargar <= 75)
            {
                distanciaCargar++;
            }
            else
            {
                distanciaCargar = 0;
            }
        }


        if (Mathf.Abs(hero.transform.position.x - transform.position.x) < 0.2f && Mathf.Abs(hero.transform.position.y - (transform.position.y + 0.5f)) < 0.2f) //Saltar encima
        {
            anim.SetTrigger("Morir");
            muerto = true;
            morir = 1;
        }
        if (morir > 0)
        {
            morir++;
        }
        if (morir == 20)
        {
            Destroy(this.gameObject);
        }



    }




}



