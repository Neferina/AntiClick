using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YunqueIA : MonoBehaviour {

    public GameObject hero; //Este es click
    private enemyPassiveAttack herocontroller; //Esto creo que no sirve pero por si acaso lo dejo

    public Sprite aire; //El sprite de cuando esta cayendo
    public Sprite tierra; //El sprite de cuando toca suelo

    public GameObject aviso; //Es el objeta que detecta cuando tiene que caer el yunque
    public Transform destino; //Es el punto donde el yunque tiene que llegar

    private bool caer; //Dice si el yunque debe caer o no
    private float speed; //Establece la velocidad de caida
    private float esperarMuerte; //Cuando toca el suelo tarda un poco en desaparecer

    private BoxCollider2D box;

    // Use this for initialization
    void Start () {
        if (destino != null) //Esto es para que el destino deje de ser hijo del yunque y este no este infinitamente cayendo
        {
            destino.parent = null; //Aquí es cuando hago lo comentado arriba
            this.gameObject.GetComponent<SpriteRenderer>().sprite = aire; //Cambio el sprite a cayendo
            caer = false; //Aun no debe caer
            speed = 5; //Velocidad del yunque
        }

        box = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (destino != null) { //Lo mismo que arriba
            comprobarSiCaer();

            if (caer == true) //Cuando click ha cruzado el umbral
            {
                float fixedSpeed = speed * Time.deltaTime; //Para determinar la caída
                transform.position = Vector3.MoveTowards(transform.position, destino.position, fixedSpeed); //Con esto se mueve click
            }

            if (transform.position == destino.position) //Detecta cuando toca el suelo el yunque
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = tierra; //Cambia el sprite al de tierra cuando llega al suelo
                esperarMuerte += Time.deltaTime;
                box.enabled = false;
                if (esperarMuerte >= 2.0f) //Cuando pasa este tiempo desaparece el enemigo
                    Destroy(this.gameObject);
            }
        }
    }

    private void comprobarSiCaer() //Comprueba si debe caer o esperar
    {
        if (aviso.transform.position.x <= hero.transform.position.x) //Una vez click cruce el umbral determinado el yunque cae
        {
            caer = true;
        }
    }
}
