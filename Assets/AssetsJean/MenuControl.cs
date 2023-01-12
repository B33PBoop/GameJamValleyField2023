using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public void StartGame()
    {
        //Ouvrir la sc�ne de jeu
        //SceneManager.LoadScene("");
    }

    public void OpenOptions()
    {
        //Ouvrir la sc�ne d'options
        //SceneManager.LoadScene("");
    }

    public void OpenCredits()
    {
        //Ouvrir la sc�ne de cr�dits
        SceneManager.LoadScene("SceneCredits");
    }

    public void OpenMainMenu()
    {
        //Ouvrir la sc�ne du menu principal
        SceneManager.LoadScene(0);

    }
}
