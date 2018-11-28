using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minionMovement : MonoBehaviour {

	public float speed;
	public Transform[] limites;
	private Rigidbody2D  rb2d;
    private Animator anim;
    public bool derecha=true;
    public GameObject hero;
    public HeroController herocontroller;
    public int morir= -1;
    public GameObject blood;


    // Use this for initialization
    void Start () {
		rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        herocontroller = GetComponent<HeroController>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetInteger("Morir", morir);
        if (derecha)
			rb2d.MovePosition (rb2d.position + Vector2.right * speed * Time.fixedDeltaTime);
		else
			rb2d.MovePosition (rb2d.position + Vector2.left * speed * Time.fixedDeltaTime);
		
		if (transform.position.x > limites [0].position.x) {
			derecha = false;
			transform.localRotation = Quaternion.Euler(0f, 180f, 0f);
		}
			

		if (transform.position.x < limites [1].position.x) {
			derecha = true;
			transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
		}
        if (Mathf.Abs(hero.transform.position.x - transform.position.x) < 0.25f && Mathf.Abs(hero.transform.position.y - transform.position.y) < 0.2f) //Saltar encima
        {
            if (morir == -1)
            {
                Instantiate(blood, transform.position, Quaternion.identity);
            }
            morir = 1;
            speed = 0;
        }
        if (morir > 0)
        {
            morir++;
        }
        if (morir == 22){
            Destroy(this.gameObject);
        }
    }
    


}
