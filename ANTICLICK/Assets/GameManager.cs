using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Metemos el scene manager

public class GameManager : MonoBehaviour {

    bool gameEnd = false;
    public Vector2 lastCheckPointPos;
    private static GameManager instance;


    public void EndGame()
    {
        gameEnd = true;

        if (gameEnd)
        {
            gameEnd = false;
            Debug.Log("Fin");
            Restart();
        }
        
    }

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
