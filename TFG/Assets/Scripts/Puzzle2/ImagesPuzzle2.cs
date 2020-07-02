using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImagesPuzzle2 : MonoBehaviour
{
    const int INITIAL_HIDDEN_PIECE = 2;
    readonly List<Vector2Int> POSICIONES_PIEZAS = new List<Vector2Int>(new Vector2Int[] { new Vector2Int(0, 0),
                                                                                          new Vector2Int(1, 0),
                                                                                          new Vector2Int(2, 0),
                                                                                          new Vector2Int(0, 1),
                                                                                          new Vector2Int(1, 1),
                                                                                          new Vector2Int(2, 1),
                                                                                          new Vector2Int(0, 2),
                                                                                          new Vector2Int(1, 2),
                                                                                          new Vector2Int(2, 2) });


    public Image[] piecesList;

    public Text TextoMovimientos;

    List<Vector3> posicionesIniciales = new List<Vector3>();
    Vector2Int posicionHueco;
    Vector2Int posicionPiezaActual;

    int contadorMovimientos = 0;

    Color hiddenColor = new Color(1, 1, 1, 0);

    bool[] comprobarHuecos; //Para ver si se puede mover hacia las otras posiciones

    List<Image> piecesMatrix;  //Mirar que está ordenada

    int hiddenPieceIndex = INITIAL_HIDDEN_PIECE;

    Image pieceToMove;


    //Cuando ganas
    public GameObject FinalPanel;
    string GuardarMovimientos;
    public Text FinalText;

    // Start is called before the first frame update
    void Start()
    {

        posicionHueco = POSICIONES_PIEZAS[INITIAL_HIDDEN_PIECE];
        piecesMatrix = new List<Image>(piecesList);

        piecesMatrix[hiddenPieceIndex].color = hiddenColor;

        for (int i = 0; i < piecesList.Length; i++)
        {
            posicionesIniciales.Add(piecesList[i].transform.position);                             //Posiciones iniciales
        }

        //Llamar método desordenación
        Barajar();

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPieceClick(Image myImage)
    {
        if (myImage.color != hiddenColor)
        {
            pieceToMove = myImage;
            posicionPiezaActual = POSICIONES_PIEZAS[piecesMatrix.IndexOf(myImage)]; //Posición que tiene ahora
        }
        else
        {
            if(pieceToMove != null)
            {
                MovePieces();
            }
        }
    } 


    void MovePieces()
    {
        bool cambioPermitido = ComprobarMovimientoValido(posicionPiezaActual);

        if (cambioPermitido)
        {
            contadorMovimientos++;
            TextoMovimientos.text = "Movimientos: " + contadorMovimientos;

            CambiarPiezas(pieceToMove, piecesMatrix[hiddenPieceIndex]);

            pieceToMove = null;

            ComprobarVictoria();

        }
    }


    bool ComprobarMovimientoValido(Vector2Int posicionPiezaActual)
    {

        bool cambioPermitido = true;

        if (posicionPiezaActual.x == posicionHueco.x && Mathf.Abs(posicionPiezaActual.y - posicionHueco.y) > 1)
        {
            cambioPermitido = false;
        }
        else if (posicionPiezaActual.y == posicionHueco.y && Mathf.Abs(posicionPiezaActual.x - posicionHueco.x) > 1)
        {
            cambioPermitido = false;
        }
        else if (posicionPiezaActual.x != posicionHueco.x && posicionPiezaActual.y != posicionHueco.y)
        {
            cambioPermitido = false;
        }

        return cambioPermitido;
    }

    void ComprobarVictoria()
    {
        bool victoria = true;

        for(int i = 0; i < piecesMatrix.Count; i++)
        {
            if("" + i != piecesMatrix[i].name)
            {
                victoria = false;
                break;
            }
        }

        if(victoria == true)
        {

            piecesMatrix[hiddenPieceIndex].color = Color.white;
            GuardarMovimientos = contadorMovimientos.ToString();
            FinalPanel.SetActive(true);
            FinalText.text = "You have solved the puzzle in " + GuardarMovimientos + " movements. Press the Exit button to turn back to the main game.";

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
              //  SceneManager.LoadScene(GlobalData.MUSEUM_SCENE_KEY);
            //}

                //print("Has ganado");
            }
    }

    //Botón para salir
    public void ButtonExitPressed()
    {
        //Debug.Log("has play");
        SceneManager.LoadScene(GlobalData.MUSEUM_SCENE_KEY);
    }

    void CambiarPiezas(Image a, Image b)
    {
        int IndexPieceA = piecesMatrix.IndexOf(a); //Sacamos su índice
        int IndexPieceB = piecesMatrix.IndexOf(b); //Sacamos su índice

        Vector3 nuevaPosicionFichaA = piecesMatrix[IndexPieceB].transform.position;
        Vector3 nuevaPosicionFichaB = piecesMatrix[IndexPieceA].transform.position;

        piecesMatrix[IndexPieceA].transform.position = nuevaPosicionFichaA;
        piecesMatrix[IndexPieceB].transform.position = nuevaPosicionFichaB;

        Image aux = piecesMatrix[IndexPieceA];
        piecesMatrix[IndexPieceA] = piecesMatrix[IndexPieceB];
        piecesMatrix[IndexPieceB] = aux;

        if(a.color == hiddenColor)
        {
            hiddenPieceIndex = piecesMatrix.IndexOf(a);
            posicionHueco = POSICIONES_PIEZAS[hiddenPieceIndex];
        }
        else if (b.color == hiddenColor)
        {
            hiddenPieceIndex = piecesMatrix.IndexOf(b);
            posicionHueco = POSICIONES_PIEZAS[hiddenPieceIndex];
        }


    }

    void Barajar()
    {

        int aleatorio;
        int numeroDeMezclas = 1000;
        int mezclasLlevadas = 0;


        while(mezclasLlevadas < numeroDeMezclas) //Con esto aseguramos que hace 50 movimientos
        //for (int i = 0; i < numeroDeMezclas; i++) //50 bucles, pero no necesariamente cambios
        {
            aleatorio = UnityEngine.Random.Range(0, piecesMatrix.Count);

            if (ComprobarMovimientoValido(POSICIONES_PIEZAS[aleatorio]))
            {
                CambiarPiezas(piecesMatrix[aleatorio], piecesMatrix[hiddenPieceIndex]);
                mezclasLlevadas++;
            }
        }
    }

}
//OnPieceClick(piecesMatrix[aleatorio1]);

//OnPieceClick(piecesMatrix[hiddenPieceIndex]);

//print("pieza1: " + aleatorio1 + ", pieza2: " + hiddenPieceIndex);