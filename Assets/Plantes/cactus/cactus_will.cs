using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus_will : MonoBehaviour
{
    public GameObject parentBalle;
    public GameObject zoneInstanciable;

    public bool isCactus = true;
    public bool isBoss = false;

    public bool playerInRange = false;
    

    void Awake()
    {
        gameObject.GetComponentInParent<PlantsAI>().trackPlayer = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AttackCactus(){
        GameObject copie = Instantiate(parentBalle, zoneInstanciable.transform);
        copie.SetActive(true);
        copie.transform.parent = null;
        //ajouter Sons
        Destroy(copie,10f);
        gameObject.GetComponent<Animator>().SetBool("Tire", false);
    }


    void OnTriggerStay(Collider objCollision)
    {
        if(objCollision.tag == "Player")
        {
            playerInRange = true;
            gameObject.GetComponentInParent<PlantsAI>().trackPlayer = true;
        }
    }

    void OnTriggerExit(Collider objCollision)
    {
        if(objCollision.tag == "Player")
        {
            playerInRange = false;
            gameObject.GetComponentInParent<PlantsAI>().trackPlayer = false;
        }
    }
}
