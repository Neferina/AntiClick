using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MassaMove : MonoBehaviour {


    private float speed = 2.5f;
    public float minSpeed;
    public float ratio;
    public GameObject hero;
    public Rigidbody2D rb;
    public float speedY = 2f;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Mathf.Abs(hero.transform.position.x - transform.position.x) > 12)
        {
            speed = Mathf.Abs(hero.transform.position.x - transform.position.x) / 3 +  5f;
        }
        else{
            speed = Mathf.Abs(hero.transform.position.x - transform.position.x) / ratio + minSpeed;
        }
        rb.velocity = Vector2.right * speed;

        if (SceneManager.GetActiveScene().name == "Cueva")
        {
            if (transform.position.x > 127f && transform.position.x<168f)
            {
                if(transform.position.y>-10f)
                    rb.velocity += Vector2.down * speed;
            }
            else if (transform.position.x > 165f)
            {

                if (transform.position.y < -2.5f)
                {
                    rb.velocity = Vector2.up * speedY;
                    rb.velocity += Vector2.right * speed;
                }

            }
        }
	}
}
