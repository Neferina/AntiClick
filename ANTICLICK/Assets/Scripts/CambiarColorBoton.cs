using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CambiarColorBoton : MonoBehaviour
{
   
    public Sprite sinPulsar;
    public Sprite pulsado;
    bool over = false;

	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sinPulsar;
    }

    void FixedUpdate()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = sinPulsar;
    }

    void OnMouseOver()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = pulsado;
    }
}
