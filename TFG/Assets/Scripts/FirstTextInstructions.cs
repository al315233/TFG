using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstTextInstructions : MonoBehaviour
{

    public GameObject instructions;
    public GameObject player;

    //Puzzle 2
    public GameObject manager;
    public GameObject canvasJuego;

    // Start is called before the first frame update
    void Start()
    {

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
        if (Input.GetKeyDown(KeyCode.Space))
        {

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
