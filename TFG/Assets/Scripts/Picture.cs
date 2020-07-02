using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;

public class Picture : MonoBehaviour
{

    public GameObject player;
    public GameObject panel;
    public GameObject panelUnderPicture;
    public Base controller;
    public Text texts;

    private bool playerDentro = false;
    


    public int cuadro; //Para indicar qué cuadro es el que estamos leyendo (0 -> Ann, 1 -> Katie, etc)
    private int i; //Índice para moverme de una frase a otra del array.


    // Start is called before the first frame update
    void Start()
    {
        i = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerDentro)
        {
            

            //enableTextUnderPicture();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                i++;

                if (i == 0) //Esto es lo que hace que no se muestre más el texto de "mira el cuadro", tener en cuenta
                {
                    //Deshabilitar player
                    FirstPersonController.Instance.SetPlayerCanMove(false);

                    enableText();
                }

                

                else if (i == controller.texts[cuadro].Length)
                { 
           
                    disableText();
                    //enableTextUnderPicture();
                    FirstPersonController.Instance.SetPlayerCanMove(true);
                }

                if (i < controller.texts[cuadro].Length && i>=0)
                {
                    texts.text = controller.texts[cuadro][i];
                }
                    
            }
            else if (Input.GetKeyDown(KeyCode.E) && i == (controller.texts[cuadro].Length - 1))
            {
                //Activar la posibilidad de jugar al minijuego de Ann.
                playAnnPuzzle();
            }
            else if (Input.GetKeyDown(KeyCode.Q) && i == (controller.texts[cuadro].Length - 1))
            {
                //Activar la posibilidad de jugar al minijuego de Katie Bouman.
                playKatiePuzzle();
            }
        }

        else
        {
            disableTextUnderPicture();
        }
        
        
    }

    private void LateUpdate()
    {
        if (playerDentro && !panel.activeSelf)
        {
            enableTextUnderPicture();
        }
    }


    private void enableTextUnderPicture()
    {
        panelUnderPicture.SetActive(true);
    }

    private void disableTextUnderPicture()
    {
        panelUnderPicture.SetActive(false);
    }


    private void enableText()
    {
        texts.text = controller.texts[cuadro][0];

        controller.inText = true;
        panel.SetActive(true);
        player.transform.LookAt(transform);

        disableTextUnderPicture();

        //anim.SetBool("isReading", true);

        //foreach(Transform child in transform){
        //if(child.tag == "Icono")
        //child.GameObject.SetActive(false);
        //}
    }

    private void disableText()
    {
        i = -1;
        controller.inText = false;
        panel.SetActive(false);
        //anim.SetBool("isReading", false);

        //foreach(Transform child in transform){
        //if(child.tag == "Icono")
        //child.GameObject.SetActive(true);
        //}

    }

    public void playAnnPuzzle()
    {
        //Debug.Log("first puzzle");
        SceneManager.LoadScene(GlobalData.LABYRINTH_SCENE_KEY);
    }

    public void playKatiePuzzle()
    {
        //Debug.Log("Katie Puzzle");
        SceneManager.LoadScene(GlobalData.JIGSAWPUZZLE_SCENE_KEY);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Player")
        {
            enableTextUnderPicture();
            playerDentro = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerDentro = false;
        }
    }
}
