using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChangeSceneFromMenu: MonoBehaviour {

    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void CargarNivel(string escena)
    {
        if(escena == "MenuPrincipal"){
            GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseManager>().Pause();
        }
        SceneManager.LoadScene(escena);
    }

}
