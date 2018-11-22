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
    }

    void Update()
    {
        if(Mathf.Abs(hero.transform.position.x - transform.position.x) < 0.2f && Mathf.Abs(hero.transform.position.y - transform.position.y)< 0.4f)
        {
            pasarNivel();
        }
    }
}
