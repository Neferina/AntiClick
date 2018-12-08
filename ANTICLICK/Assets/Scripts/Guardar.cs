using UnityEngine;
using UnityEngine.UI;

public class Guardar : MonoBehaviour {

    public int cave, snow, castle;
    public Transform cueva, nieve, castillo;

    void Start()
    {

        cave = PlayerPrefs.GetInt("Cave");
        snow = PlayerPrefs.GetInt("Snow");
        castle = PlayerPrefs.GetInt("Castle");

        if (cave == 0)
        {
            cueva.GetComponent<Button>().interactable = false;
        } else
        {
            cueva.GetComponent<Button>().interactable = true;
        }

        if (snow == 0)
        {
            nieve.GetComponent<Button>().interactable = false;
        }
        else
        {
            nieve.GetComponent<Button>().interactable = true;
        }

        if (castle == 0)
        {
            castillo.GetComponent<Button>().interactable = false;
        }
        else
        {
            castillo.GetComponent<Button>().interactable = true;
        }
    }

}
