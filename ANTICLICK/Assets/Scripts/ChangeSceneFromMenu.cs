using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ChangeSceneFromMenu: MonoBehaviour {

    private string actual;


	
	// Update is called once per frame
	void Update () {
        actual = SceneManager.GetActiveScene().name;
	}

	public void CargarNivel(string escena)
    {
        if (actual == "Pradera" || actual == "Cueva" || actual == "Castillo" || actual == "Nieve")
        {
            if (escena == "MenuPrincipal")
            {
                GameObject.FindGameObjectWithTag("Pause").GetComponent<PauseManager>().Pause();
            }
        }


        SceneManager.LoadScene(escena);

    }



}
