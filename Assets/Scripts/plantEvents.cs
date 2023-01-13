using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantEvents : MonoBehaviour
{
    public GameObject refTableau;
    public GameObject prefabEmpty;
    public static int nbPlanteWatered = 0;
    public bool isDead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        Invoke("TagPlante",0.2f);
    }
    
    void TagPlante(){
        gameObject.tag = "plante";
    }

    
}
