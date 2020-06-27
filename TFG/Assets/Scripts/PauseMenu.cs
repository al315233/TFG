using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    bool gamePaused;

    public GameObject Elements;

    //crear variable pública slider y asignarlo en el hierarchy
    //Copiar código

    private AudioSource audioSrc;

    public Slider VolumenSlider;

    //Singleton

    public static PauseMenu Instance;


    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        Elements.SetActive(false);

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = VolumenSlider.value;

        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }


    void pauseGame()
    {
        if (gamePaused) //Despausar juego
        {
            Elements.SetActive(true);
            Time.timeScale = 1;
            gamePaused = false;
        }
        else //Pausar juego
        {
            Elements.SetActive(false);
            Time.timeScale = 0;
            gamePaused = true;
        }
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene("FirstMenu");
    }

    public void OnBackButtonClick()
    {
        pauseGame();
        //SceneManager.LoadScene("scene1");
    }
}
