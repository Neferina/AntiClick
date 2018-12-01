using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidahero : MonoBehaviour { 
//Detecta cuando CLICK ha sido alcanzado por un ENEMIGO, 
//cambia a rojo el color del sprite y el enemigo (o su arma) lo empuja hacia atras	
	
	Rigidbody2D rb2d;
    public int cantidadVidas;
	Animator anim;

	public float SaltoX, SaltoY;
	private HeroController hero;
    public LifeSprites corazones;

	bool invencible=false;

	void Awake()
	{
		anim = GameObject.Find ("gameover").GetComponent<Animator> ();
	}

	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D> ();
		hero = GetComponentInParent<HeroController>(); //Necesita acceder a HeroController para comprobar si 
                                                       //su variable "tocado" es true o false

        cantidadVidas = 3;
        corazones = GameObject.FindObjectOfType<LifeSprites>();
	}

    public void Update()
    {
        corazones.cambioVida(cantidadVidas);
    }

    public void  OnCollisionEnter2D(Collision2D other) { //Si han alcanzado a CLICK, salta hacia atras y se vuelve rojo
		if(hero.tocado)
		{
			GetComponent<SpriteRenderer> ().color = Color.red;
			if (!invencible) {
				cantidadVidas--;
				Debug.Log ("Tocado");
				corazones.cambioVida(cantidadVidas);
				StartCoroutine (Invencible ());
				hero.tocado = false;

			}
            

            if (hero.right)
            {
                rb2d.velocity = new Vector2(SaltoX, SaltoY);
            }else if(hero.right != true)
            {
                rb2d.velocity = new Vector2(-SaltoX, SaltoY);
            }

        }

        if (cantidadVidas < 1)
        {

			anim.SetTrigger ("gameover");
			StartCoroutine (Reiniciar());
        }
		
	}

	IEnumerator Reiniciar()
	{
		yield return new WaitForSeconds (1.5f);
		FindObjectOfType<GameManager>().EndGame();
	}

	public void  OnCollisionExit2D(Collision2D col) {		
		if(!hero.tocado) //restablece o mantiene el color normal de CLICK
		{
			GetComponent<SpriteRenderer> ().color = Color.white;


		}

	}

	IEnumerator Invencible()
	{
		invencible = true;
		yield return new WaitForSeconds (1.5f);
		invencible = false;
	}
}