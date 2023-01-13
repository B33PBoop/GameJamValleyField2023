using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Champignon_Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }



    public GameObject zoneDegat;
    public bool isBoss = false;

    public bool isCactus = false;
    public bool playerInRange = true;
    
    // Update is called once per frame
    void Update()
    {
        
    }
    void AttackChampi(){
        zoneDegat.SetActive(true);
    }

    void ArreteChampi(){
        zoneDegat.SetActive(false);
        gameObject.GetComponent<Animator>().SetBool("Tire", false);
    }
}
