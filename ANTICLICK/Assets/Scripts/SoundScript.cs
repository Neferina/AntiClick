using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public GameObject hero;
    public GameObject masa;
    private Vector3 posicion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update()
    {
        posicion = new Vector3(masa.transform.position.x, hero.transform.position.y, 0);
        transform.position = posicion;
    }
}
