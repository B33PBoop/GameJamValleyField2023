using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoutonsMenu : MonoBehaviour
{
    public static bool persoA = true;
    public static float intensiteSon;
    public Slider mainSlider;
    // Start is called before the first frame update
    void Start()
    {
        persoA = true;
    }

    // Update is called once per frame
    void Update()
    {
        intensiteSon = mainSlider.value;
        Debug.Log(mainSlider.value);
    }
    public void ChangerScene()
    {
        SceneManager.LoadScene("TheGameMap");
    }

    public void PersoA()
    {
        persoA = true;
    }
    public void PersoB()
    {
        persoA = false;
    }
}
