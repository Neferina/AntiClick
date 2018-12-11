using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidahero : MonoBehaviour { 
//Detecta cuando CLICK ha sido alcanzado por un ENEMIGO, 
//cambia a rojo el color del sprite y el enemigo (o su arma) lo empuja hacia atras	
	
	Rigidbody2D rb2d;
    public int cantidadVidas;
    public LifeSprites corazones;
    private HeroController hero;
    Animator anim;
    Animator heroAnim;

	public float SaltoX, SaltoY;
    private bool salto = true;
	
    
    public float DeathDelay = 0.8f;

	//bool invencible=false;

	void Awake()
	{
		anim = GameObject.Find ("gameover").GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		//rb2d = GetComponent<Rigidbody2D> ();
		//hero = GetComponentInParent<HeroController>(); //Necesita acceder a HeroController para comprobar si su variable "tocado" es true o false                       

        cantidadVidas = 3;
        corazones = GameObject.FindObjectOfType<LifeSprites>();
	}

    public void Update()
    {
        corazones.cambioVida(cantidadVidas);
        /*
        if (cantidadVidas < 1)
        {
            hero.dead = true;
            GetComponent<SpriteRenderer>().color = Color.white;
            DeathDelay -= Time.deltaTime;
        }

        if (DeathDelay <= 0)
        {
            anim.SetTrigger("gameover");
            StartCoroutine(Reiniciar());
            hero.dead = false;
        }

        if (!hero.tocado) //restablece o mantiene el color normal de CLICK
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }

        
        if(rb2d.velocity.y < 0.1 && hero.isGrounded && !salto)
        {
            salto = true;
            hero.tocado = false;
            invencible = false;
        }
    }

    /*
    public void  OnCollisionEnter2D(Collision2D other) { //Si han alcanzado a CLICK, salta hacia atras y se vuelve rojo
		if(hero.tocado && !hero.dead)
		{
			GetComponent<SpriteRenderer> ().color = Color.red;
			if (!invencible) {
				cantidadVidas--;
				Debug.Log ("Tocado");
				corazones.cambioVida(cantidadVidas);
                invencible = true;
                //StartCoroutine (Invencible ());
            }
            
            
            if (hero.right && salto)
            {
                rb2d.velocity = new Vector2(SaltoY, SaltoY);
                salto = false;

            }
            else if(!hero.right && salto)
            {
                rb2d.velocity = new Vector2(SaltoY, SaltoY);
                salto = false;
            }
            */

    }



}
/*
	IEnumerator Reiniciar()
	{
		yield return new WaitForSeconds (1.5f);
		FindObjectOfType<GameManager>().EndGame();
	}

   
    IEnumerator Invencible()
	{
		invencible = true;
		yield return new WaitForSeconds (1.8f);
		invencible = false;
    }
    */