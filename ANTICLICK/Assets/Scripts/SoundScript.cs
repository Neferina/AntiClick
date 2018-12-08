using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour {

    public GameObject hero;
    public GameObject masa;
    public float limite;
    private AudioSource fuente;
    private Vector3 posicion;
	// Use this for initialization
	void Start () {
        fuente = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update()
    {
        fuente.volume = 1.0f - Mathf.Abs(hero.transform.position.x - masa.transform.position.x) / limite;
    }
}
