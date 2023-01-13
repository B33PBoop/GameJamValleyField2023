using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        //Ouvrir la scène de jeu
        //SceneManager.LoadScene("");
    }

    public void OpenOptions()
    {
        //Ouvrir la scène d'options
        //SceneManager.LoadScene("");
    }

    public void OpenCredits()
    {
        //Ouvrir la scène de crédits
        SceneManager.LoadScene("SceneCredits");
    }

    public void OpenMainMenu()
    {
        //Ouvrir la scène du menu principal
        SceneManager.LoadScene(0);

    }
}
