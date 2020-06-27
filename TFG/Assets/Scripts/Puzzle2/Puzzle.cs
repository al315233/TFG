using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour

   {

    public List<Sprite> fichaImg = new List<Sprite>();
    public GameObject fichaPrfb;
    public GameObject bordePrfb;
    public Sprite fichaEscondidaImg;
    public GameObject textoGanador;

    GameObject fichaEscondida;
    int numCostado;
    GameObject padreFichas;
    GameObject padreBordes;
    List<Vector3> posicionesIniciales = new List<Vector3>();
    GameObject[] _fichas;

    bool[] comprobarHuecos;


    private void Awake()
    {
        padreFichas = GameObject.Find("Fichas");
        padreBordes = GameObject.Find("Bordes");
    }


    // Start is called before the first frame update
    void Start()
    {

        comprobarHuecos = new bool[9];

        //De esta manera se comprueba que es un número cuadrado
        if(Mathf.Sqrt(fichaImg.Count) == Mathf.Round(Mathf.Sqrt(fichaImg.Count)))
        {
            CrearFichas();

        }
        else
        {
            print("Imposible crear fichas");
        }
    }

    void CrearFichas()
    {
        int contador = 0;
        numCostado = (int)Mathf.Sqrt(fichaImg.Count);

        //Bucles anidados para colocar las fichas en su sitio (en fin...)
        for (int alto = numCostado + 2; alto > 0; alto--){
            for(int ancho = 0; ancho < numCostado + 2; ancho++)
            {
                Vector3 posicion = new Vector3(ancho - (numCostado / 2), alto - (numCostado / 2), 0); //Posición de cada ficha

                //Comprobar si son posiciones de borde o de ficha
                if(alto == 1 || alto == numCostado + 2 || ancho == 0 || ancho == numCostado + 1) //Esto quiere decir que es parte del borde
                {
                    GameObject borde = Instantiate(bordePrfb, posicion, Quaternion.identity);   //Instanciamos el borde
                    borde.transform.parent = padreBordes.transform;                             //Lo ponemos como hijo de PadreBordes
                }           
                else //Es parte del puzzle
                {
                    GameObject ficha = Instantiate(fichaPrfb, posicion, Quaternion.identity);   //Instanciamos la ficha
                    ficha.GetComponent<SpriteRenderer>().sprite = fichaImg[contador];           //Asignamosel sprite a cada ficha
                    ficha.transform.parent = padreFichas.transform;                             //Lo ponemos como hijo de PadreFichas
                    ficha.name = fichaImg[contador].name;                                       //Dejamos el mismo nombre que el sprite
                    if(ficha.name == fichaEscondidaImg.name)                                    //Si es la ficha que tenemos que esconder
                    {
                        fichaEscondida = ficha;                                                 //La asignamos

                    }

                    contador++;
                }
            }
        }

        fichaEscondida.gameObject.SetActive(false);                                             //Escondemos la fichaEscondida

        //Almacenar las posiciones iniciales

        _fichas = GameObject.FindGameObjectsWithTag("Ficha");                                   //Recuperamos todas las fichas con el tag ficha
        for(int i = 0; i < _fichas.Length; i++)
        {
            posicionesIniciales.Add(_fichas[i].transform.position);                             //Asignamos las posiciones iniciales a las fichas
        }

        //Barajar las fichas aleatoriamente

        Barajar();
        
    }

    void Barajar()
    {

        int aleatorio;

        for (int i = 0; i < _fichas.Length; i++)
        {
            aleatorio = Random.Range(i, _fichas.Length);                            //Creamos un número aleatorio entre 0 y el número de fichas
            Vector3 posTemp = _fichas[i].transform.position;                        //En una variable temporal guardamos la posición inicial
            _fichas[i].transform.position = _fichas[aleatorio].transform.position;  //Cambiamos la posición ficha[aleatorio] por ficha[i]
            _fichas[aleatorio].transform.position = posTemp;                        //Asignamos la posición inicial que habíamos guardado a fichas[aleatorio]
        }
    }

    public void ComprobarGanador()
    {
        for(int i = 0; i < _fichas.Length; i++)
        {
            if(posicionesIniciales[i] != _fichas[i].transform.position) //Repasamos las posiciones actuales y solo que una ya no tenga la misma posición que la inicial salimos de la función.
            {
                return;

            }
        }
        fichaEscondida.gameObject.SetActive(true); //Si llegamos aquí es que se ha resuelto el puzzle
        print("Puzzle resuelto!");
        textoGanador.gameObject.SetActive(true);
    }
}
