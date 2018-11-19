using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPassiveAttack : MonoBehaviour
{
    //Comprueba si un enemigo colisiona o no con CLICK



    private HeroController hero;

    public Collider2D coll;

    // Use this for initialization
    void Start()
    {

        hero = GetComponentInParent<HeroController>();
    }


    void OnCollisionEnter2D(Collision2D col)
    { //Si colisiona con CLICK comprueba:


        if (col.gameObject.tag == "massa")
        {
            FindObjectOfType<GameManager>().Restart();
        }

        if (col.gameObject.tag == "Enemy")
        { //1. Si colisiona de lado. Si es asi, cambia a true la variable de HeroCOntroller
            hero.tocado = true;
        }


        if ((col.gameObject.tag == "Enemy") && (hero.isGrounded == false))
        { //2. Si CLCIK salta sobre el ENEMIGO
            hero.tocado = false;
            Destroy(col.gameObject); //Se destruye
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            hero.tocado = false;

        }

    }




}
