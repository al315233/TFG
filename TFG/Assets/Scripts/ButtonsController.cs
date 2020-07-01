using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void PlayGame()
    {
        //Debug.Log("has play");
        SceneManager.LoadScene(GlobalData.MUSEUM_SCENE_KEY);
    }

    public void ShowCredits()
    {
        //Debug.Log("Credits");
        SceneManager.LoadScene(GlobalData.CREDITSSCREEN_SCENE_KEY);
    }

    public void ShowOptions()
    {
        //Debug.Log("Options");
        SceneManager.LoadScene(GlobalData.OPTIONSCREEN_SCENE_KEY);
    }

    public void QuitGame()
    {
        //Debug.Log("has quit the game lol");
        Application.Quit();
    }

    public void BackButton() //Volver a la pantalla de título desde créditos
    {
        //Debug.Log("Back Button pressed");
        SceneManager.LoadScene(GlobalData.FIRSTMENU_SCENE_KEY);
    }

/*    public void BackToGameButton()
    {
        Debug.Log("Back Button pressed");
        //SceneManager.LoadScene("");
    }
    */
}
