using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class recogerMonedas : MonoBehaviour {

	public int cofre = 0;
	Text text;
	 /* void Start () {
		trfm = GetComponent<Transform>();
		
    } */
	void Awake()
	{
		text = GameObject.Find ("score").GetComponent<Text> ();
	}

	public void update() {
		transform.localScale = new Vector3(1.5F, 1.5F, 0);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Recolectable"){
			cofre = cofre + 1;
			text.text = "Score: " + cofre;
			Destroy(col.gameObject);
		}
	
	}
}
