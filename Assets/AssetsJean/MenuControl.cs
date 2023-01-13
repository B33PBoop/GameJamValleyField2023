using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        //Ouvrir la sc�ne de jeu
        SceneManager.LoadScene("TheGame");
    }

    public void OpenControls()
    {
        //Ouvrir la sc�ne des contr�les
        SceneManager.LoadScene("SceneControls");
    }

    public void OpenOptions()
    {
        //Ouvrir la sc�ne d'options
        SceneManager.LoadScene("SceneOptions");
    }

    public void OpenCredits()
    {
        //Ouvrir la sc�ne de cr�dits
        SceneManager.LoadScene("SceneCredits");
    }

    public void OpenMainMenu()
    {
        //Ouvrir la sc�ne du menu principal
        SceneManager.LoadScene("MainMenu");

    }
}
