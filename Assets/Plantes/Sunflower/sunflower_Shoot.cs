using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunflower_Shoot : MonoBehaviour
{
    public GameObject zoneDegat;
    public bool isBoss = true;

    public bool isCactus = false;
    public bool playerInRange = true;
    
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
        gameObject.GetComponent<Animator>().SetBool("Tire", false);
    }

    void ArretFollow(){
        gameObject.GetComponentInParent<PlantsAI>().trackPlayer = false;
    }
    
    void DebutFollow() 
    {
        gameObject.GetComponentInParent<PlantsAI>().trackPlayer = true;
    }
}
