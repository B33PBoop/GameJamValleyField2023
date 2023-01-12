using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantEvents : MonoBehaviour
{
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
    void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "spawning")
        {
            Destroy(gameObject,0f);
        }
    }

    void TagPlante(){
        gameObject.tag = "plante";
    }
}
