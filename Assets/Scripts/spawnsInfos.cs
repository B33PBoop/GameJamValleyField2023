using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsInfos : MonoBehaviour
{

    GameObject plantSpawnRef;
    // Start is called before the first frame update
    public bool latestSpawn = true;
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerStay(Collider other)
    {
        if(other.tag != "Terrain" && gameObject.name != "Keep")
        {
            if(latestSpawn)
            {
                plantSpawnRef.GetComponent<plantSpawner>().spawnList.Remove(this.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
