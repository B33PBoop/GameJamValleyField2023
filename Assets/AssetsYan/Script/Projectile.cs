using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Projectile : MonoBehaviour
{
    /*
     * SCRIPT DE PROJECTILE
     */

    //Tres simple script pour fair deplacer les instance de boul de feu
    //on detruit les boul de feu au contact d'un object


    public GameObject Character;
    public float projectileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = Character.transform.forward * projectileSpeed;
        Destroy(gameObject, 10f);
    }
 
    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag != "Environement")
        {
            Destroy(gameObject);
        }
    }
}
