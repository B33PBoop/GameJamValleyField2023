using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunflower_Shoot : MonoBehaviour
{
    public GameObject zoneDegat;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void AttackSunflower(){
        zoneDegat.SetActive(true);
        Invoke("EteindrePlante",4f);
        //ajouter Sons
    }

    void EteindrePlante(){
        zoneDegat.SetActive(false);
    }
}
