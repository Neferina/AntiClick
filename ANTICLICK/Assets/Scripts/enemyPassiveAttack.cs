using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPassiveAttack : MonoBehaviour {
//Comprueba si un enemigo colisiona o no con CLICK
	

	private HeroController hero;
    private PasarNivel banderin;
    private Animator anim;

    public Collider2D coll;
    public int cofre = 0;
	// Use this for initialization
	void Start () {
		
		hero = GetComponentInParent<HeroController>();
        banderin = GetComponent<PasarNivel>();
        anim = GetComponent<Animator>();
	}


    void OnCollisionEnter2D(Collision2D col){ //Si colisiona con CLICK comprueba:
		

        if(col.gameObject.tag == "massa")
        {
            FindObjectOfType<GameManager>().Restart();
        }

		if(col.gameObject.tag == "Enemy" && col.transform.position.y > transform.position.y+0.5)
        { //1. Si colisiona de lado. Si es asi, cambia a true la variable de HeroCOntroller
			hero.tocado = true;	
		}

        if (col.gameObject.tag == "Bufa") //Cuando la bufa saca el pincho tocarla desde cualquier punto es recibir daño
        {
            hero.tocado = true;
        }

        if (col.gameObject.tag == "Cat")
        {
            Debug.Log("Tocadoooo");
        }

    }

	void OnCollisionExit2D(Collision2D col){

		if(col.gameObject.tag == "Cat"){
			hero.tocado = false;
            anim.SetBool("Golpeado", false);
        }
	
	}


}
