using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //Metemos el scene manager



public class GameManager : MonoBehaviour
{

    bool gameEnd = false;

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

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


