using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recogerMonedas : MonoBehaviour {

	public int cofre = 0;

	void OnCollisionEnter2D(Collision2D col){
		if(col.gameObject.tag == "Recolectable"){
			cofre = cofre + 1;
			Destroy(col.gameObject);
		}
	
	}
}
