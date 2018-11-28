using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour {

    public GameObject hero;


    public void pasarNivel()
    {
        if(SceneManager.GetActiveScene().name == "Pradera")
        {
            SceneManager.LoadScene("Cueva");
        }
        if (SceneManager.GetActiveScene().name == "Cueva")
        {
            SceneManager.LoadScene("Nieve");
        }
        if (SceneManager.GetActiveScene().name == "Nieve")
        {
            SceneManager.LoadScene("Castillo");
        }
        if (SceneManager.GetActiveScene().name == "Castillo")
        {
            SceneManager.LoadScene("Menu Principal");
        }
    }

    void Update()
    {
        if(Mathf.Abs(hero.transform.position.x - transform.position.x) < 0.4f)
        {
            pasarNivel();
        }
    }
}
