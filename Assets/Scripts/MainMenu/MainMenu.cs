using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{

    public void PlayTutotial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayVersus()
    {
        SceneManager.LoadScene("Versus");
    }

    public void PlayKingOfTheHill()
    {
        SceneManager.LoadScene("Koth");
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene("");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
