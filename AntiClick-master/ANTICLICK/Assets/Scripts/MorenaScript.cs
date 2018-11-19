using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorenaScript : MonoBehaviour {

    public float speed;
    private bool movingUp = true;
    public Transform[] limit;
    Rigidbody2D myBody;



    // Use this for initialization
    void Start()
    {

        myBody = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (movingUp)
        {
            myBody.MovePosition(myBody.position + Vector2.up * speed * Time.fixedDeltaTime);
        }
        else
        {
            myBody.MovePosition(myBody.position + Vector2.down * speed * Time.fixedDeltaTime);
        }

        if (transform.position.y >= limit[0].position.y)
        {
            movingUp = false;
        }

        if (transform.position.y <= limit[1].position.y)
        {
            movingUp = true;
        }
    }
}
