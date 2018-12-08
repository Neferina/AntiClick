using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSprites : MonoBehaviour {

    public Sprite[] corazones;

	// Use this for initialization
	void Start () {
        cambioVida(3);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void cambioVida(int posicion)
    {
        if (posicion > -1)
        {
            this.GetComponent<Image>().sprite = corazones[posicion];
        }
    }

}
