using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsController : MonoBehaviour
{
    public void PlayGame()
    {
        Debug.Log("has play");
        SceneManager.LoadScene("Scene1");
    }

    public void ShowCredits()
    {
        Debug.Log("Credits");
        SceneManager.LoadScene("CreditsScene");
    }

    public void ShowOptions()
    {
        Debug.Log("Options");
        SceneManager.LoadScene("OptionsScreen");
    }

    public void QuitGame()
    {
        Debug.Log("has quit the game lol");
        Application.Quit();
    }

    public void BackButton() //Volver a la pantalla de título desde créditos
    {
        Debug.Log("Back Button pressed");
        SceneManager.LoadScene("FirstMenu");
    }

    public void BackToGameButton()
    {
        Debug.Log("Back Button pressed");
        //SceneManager.LoadScene("");
    }

}
