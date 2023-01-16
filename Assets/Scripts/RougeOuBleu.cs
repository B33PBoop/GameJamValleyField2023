using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RougeOuBleu : MonoBehaviour
{

    public GameObject persoCouleur;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.GetComponent<BoutonsMenu>().persoA) 
        {
            persoCouleur.SetActive(true);
        }
    }
}
