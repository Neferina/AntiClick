using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playsound : MonoBehaviour {
	public AudioClip salto;
	public AudioClip monedas;
	public AudioClip dash;
	public AudioClip muerte;
    public AudioClip respects;
    private HeroController hero;

	AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
        hero = GetComponent<HeroController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.UpArrow) && hero.isGrounded) {
			audio.clip = salto;
			audio.Play ();
		}
        if (Input.GetKeyDown(KeyCode.F))
        {
            audio.clip = respects;
            audio.Play();
        }

    }

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.CompareTag ("Recolectable")) {
			audio.clip = monedas;
			audio.Play ();
		}
	}

	public void PlayDash()
	{
		audio.clip = dash;
		audio.Play ();
	}




}
