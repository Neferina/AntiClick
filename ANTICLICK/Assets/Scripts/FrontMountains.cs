using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontMountains : MonoBehaviour {
    public GameObject character;
    public float ratioX = 0.2f;
    public float ratioY = 0.3f;
    public float offsetX = -5f;
    public float offsetY = 3f;
    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        float posX = character.transform.position.x;
        float posY = character.transform.position.y;

        transform.position = new Vector3(posX*ratioX + offsetX, posY*ratioY + offsetY, transform.position.z);
    }
}
