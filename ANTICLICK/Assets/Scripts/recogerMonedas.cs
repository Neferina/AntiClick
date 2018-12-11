using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recogerMonedas : MonoBehaviour {

	public int cofre = 0;
    public int vidaExtra = 0;
    private vidahero vidas;
	Text text;


	void Start () {
        vidas = GetComponentInParent<vidahero>();
		
    } 
	void Awake()
	{
		text = GameObject.Find ("score").GetComponent<Text> ();
	}

	void Update() {

        if (vidaExtra >= 50)
        {
            if (vidas.cantidadVidas < 3)
            {
                vidas.cantidadVidas++;
                
            }
            vidaExtra -= 50;
        }

	}




    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Recolectable")
        {
            cofre = cofre + 1;
            vidaExtra = vidaExtra + 1;
            text.text = "Score: " + cofre;
            Destroy(col.gameObject);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Cat")
        {
            cofre = cofre + 20;
            vidaExtra = vidaExtra + 20;
            text.text = "Score: " + cofre;
        }
    }
}
