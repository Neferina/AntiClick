using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogerMonedas : MonoBehaviour {

	public int cofre = 0;
	 /* void Start () {
		trfm = GetComponent<Transform>();
		
    } */
	public void update() {
		transform.localScale = new Vector3(1.5F, 1.5F, 0);
	}

	public void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Recolectable"){
			cofre = cofre + 1;
			Destroy(col.gameObject);
		}
	
	}
}
