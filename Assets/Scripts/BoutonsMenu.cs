using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BoutonsMenu : MonoBehaviour
{
    public bool persoA = true;
    public static float intensiteSon;
    public Slider mainSlider;
    public GameObject options;
    public GameObject credit;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        persoA = true;
    }

    // Update is called once per frame
    void Update()
    {
        intensiteSon = mainSlider.value;
    }
    public void OuvrirOptions() {
        options.SetActive(true);
    }
    public void OuvrirCredit() {
        credit.SetActive(true);
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
    public void FermeMenuOption()
    {
        options.SetActive(false);
    }
    public void FermeMenuCredit()
    {
        credit.SetActive(false);
    }
}
