using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cactus_will : MonoBehaviour
{
    public GameObject cube;
    public GameObject parentBalle;
    public GameObject zoneInstanciable;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.LookAt(cube.transform);
    }

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
