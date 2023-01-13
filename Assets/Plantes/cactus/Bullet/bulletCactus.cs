using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCactus : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
         transform.Translate(Vector3.forward * Time.deltaTime);
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
