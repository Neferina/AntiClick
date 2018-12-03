using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasarNivel : MonoBehaviour {

    public GameObject hero;
    public GameManager gm;



    public void pasarNivel()
    {
        if(SceneManager.GetActiveScene().name == "Pradera")
        {
            gm.lastCheckPointPos = new Vector2(-2.91f, -4.30f);
            hero.transform.position = gm.lastCheckPointPos;
            SceneManager.LoadScene("Cueva");
            Debug.Log(gm.lastCheckPointPos);
        }
        if (SceneManager.GetActiveScene().name == "Cueva")
        {
            gm.lastCheckPointPos = new Vector2(-1f, -1.7f);
            SceneManager.LoadScene("Nieve");
        }
        if (SceneManager.GetActiveScene().name == "Nieve")
        {
            gm.lastCheckPointPos = new Vector2(-3f, 1.2f);
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
