using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus_will : MonoBehaviour
{
    public GameObject parentBalle;
    public GameObject zoneInstanciable;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void AttackCactus(){
        GameObject copie = Instantiate(parentBalle, zoneInstanciable.transform);
        copie.SetActive(true);
        //ajouter Sons
        Destroy(copie,10f);
    }
}
