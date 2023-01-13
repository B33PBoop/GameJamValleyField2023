using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunflower_Single_shoot : MonoBehaviour
{
    public GameObject parentBalle;
    public GameObject zoneInstanciable;

    public bool isCactus = false;
    public bool isBoss = false;

    public bool playerInRange = true;
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackSunflower(){
        GameObject copie = Instantiate(parentBalle, zoneInstanciable.transform);
        copie.SetActive(true);
        copie.transform.parent = null;
        //ajouter Sons
        Destroy(copie,10f);
        //gameObject.GetComponent<Animator>().SetBool("Tire", false);
    }

}
