using UnityEngine;
using System.Collections;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseManager : MonoBehaviour {
    
    Canvas canvas;
    
    void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    
    public void Pause()
    {
        canvas.enabled = !canvas.enabled;//activa o desactiva el canvas
        Time.timeScale = Time.timeScale == 0 ? 1 : 0; //va a hacer que continue el juego o al reves
    }
    
    public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}