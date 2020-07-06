using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class FirstTextInstructions : MonoBehaviour
{

    private GameObject player;

    public GameObject instructions;

    bool activo = false;

    //Puzzle 2
    public GameObject manager;
    public GameObject canvasJuego;

    // Start is called before the first frame update
    void Start()
    {
        if(FirstPersonController.Instance != null)
        {
            player = FirstPersonController.Instance.gameObject;
        }
        //Todos los puzzles
        instructions.SetActive(true);

        if(player != null)
        {

            //Puzzle 1
            player.SetActive(false);
        }

        //Puzzle 2
        manager.SetActive(false);
        canvasJuego.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !activo)
        {
            activo = true;
            switch (SceneManager.GetActiveScene().name)
            {
                case GlobalData.MUSEUM_SCENE_KEY:
                    Camera.main.gameObject.SetActive(false);
                    break;
            }
            
            //Todos los puzzles
            instructions.SetActive(false);

            //Puzzle 1
            if (player != null)
            {

                //Puzzle 1
                player.SetActive(true);
            }

            //Puzzle 2
            manager.SetActive(true);
            canvasJuego.SetActive(true);
        }
    }
}
