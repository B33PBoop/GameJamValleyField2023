using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        //Ouvrir la scène de jeu
        SceneManager.LoadScene("TheGame");
    }

    public void OpenControls()
    {
        //Ouvrir la scène des contrôles
        SceneManager.LoadScene("SceneControls");
    }

    public void OpenOptions()
    {
        //Ouvrir la scène d'options
        SceneManager.LoadScene("SceneOptions");
    }

    public void OpenCredits()
    {
        //Ouvrir la scène de crédits
        SceneManager.LoadScene("SceneCredits");
    }

    public void OpenMainMenu()
    {
        //Ouvrir la scène du menu principal
        SceneManager.LoadScene("MainMenu");

    }
}
