using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour {

    public GameObject character;
    public Vector2 minCamPos, maxCamPos;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        float posX = character.transform.position.x;

        transform.position = new Vector3(Mathf.Clamp(posX, minCamPos.x, maxCamPos.x), transform.position.y, transform.position.z);
	}
}
