using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
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

        VolumenSlider.value = GlobalData.GameVolume;
        Elements.SetActive(false);

        // Assign Audio Source component to control it
        audioSrc = GetComponent<AudioSource>();
    }

    private void LateUpdate()
    {
        Cursor.lockState = GlobalData.GamePaused || GlobalData.LevelsWithCursor.Contains(SceneManager.GetActiveScene().name) ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = GlobalData.GamePaused || GlobalData.LevelsWithCursor.Contains(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        // Setting volume option of Audio Source to be equal to musicVolume
        audioSrc.volume = VolumenSlider.value;

        GlobalData.GameVolume = VolumenSlider.value;


        if (Input.GetKeyDown(KeyCode.P))
        {
            pauseGame();
        }
    }


    void pauseGame()
    {
        if (GlobalData.GamePaused) //Despausar juego
        {
            //Cursor.visible = false;
            Elements.SetActive(false);
            Time.timeScale = 1;
            GlobalData.GamePaused = false;
        }
        else //Pausar juego
        {
            //Cursor.visible = true;
            Elements.SetActive(true);
            Time.timeScale = 0;
            GlobalData.GamePaused = true;
        }
    }

    public void OnMainMenuClick()
    {
        SceneManager.LoadScene(GlobalData.FIRSTMENU_SCENE_KEY);
    }

    public void OnBackButtonClick()
    {
        pauseGame();
        //SceneManager.LoadScene("scene1");
    }
}
