using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PasarNivel : MonoBehaviour {

    public GameObject hero;
    public GameManager gm;
    private GameObject[] win;

    public Image[] imagenes;
    public float tiempoEspera;

    public void Start()
    {

        
        for (int i = 0; i < imagenes.Length; i++)
        {
            Vector4 alfa = new Vector4(imagenes[i].color.r, imagenes[i].color.g, imagenes[i].color.b, 0f);
            imagenes[i].color = alfa;
        }


    }

    public void pasarNivel()
    {
        if(SceneManager.GetActiveScene().name == "Pradera")
        {
            gm.lastCheckPointPos = new Vector2(-2.91f, -4.30f);
            hero.transform.position = gm.lastCheckPointPos;
            PlayerPrefs.SetInt("Cave", 1); //Guarda la partida y desbloquea el nivel de la cueva
            SceneManager.LoadScene("Cueva");
            Debug.Log(gm.lastCheckPointPos);
        }
        if (SceneManager.GetActiveScene().name == "Cueva")
        {
            gm.lastCheckPointPos = new Vector2(-1f, -1.7f);
            PlayerPrefs.SetInt("Snow", 1); //Guarda la partida y desbloquea el nivel de la nieve
            SceneManager.LoadScene("Nieve");
        }
        if (SceneManager.GetActiveScene().name == "Nieve")
        {
            gm.lastCheckPointPos = new Vector2(-3f, 1.2f);
            PlayerPrefs.SetInt("Castle", 1); //Guarda la partida y desbloquea el nivel del castillo
            SceneManager.LoadScene("Castillo");
        }
        if (SceneManager.GetActiveScene().name == "Castillo")
        {
            
            for (int i = 0; i < imagenes.Length; i++)
            {
                Vector4 alfa = new Vector4(imagenes[i].color.r, imagenes[i].color.g, imagenes[i].color.b, 1f);
                imagenes[i].color = alfa;
            }

            tiempoEspera = 0;
            while(tiempoEspera < 2f)
            {
                tiempoEspera += Time.deltaTime;
            }
            SceneManager.LoadScene("MenuPrincipal");

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
