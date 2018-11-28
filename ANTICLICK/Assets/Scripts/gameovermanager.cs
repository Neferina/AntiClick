using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameovermanager : MonoBehaviour {

	public void Reiniciar()
	{
		FindObjectOfType<GameManager>().EndGame();
	}
}
