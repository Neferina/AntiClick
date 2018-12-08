using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huesoMovimiento : MonoBehaviour {

    private float force = 5.0f;
    public float direccion = -1;
    private float lifeTime = 0.85f;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start () {
            rb2d.velocity = new Vector2(force*direccion, force);
	}
	
	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
        if(lifeTime < 0)
        {
            Destroy(this.gameObject);
        }
    }

}
