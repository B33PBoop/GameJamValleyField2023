using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantSpawner : MonoBehaviour
{
    
    public GameObject prefabPlante;
    public List<GameObject> spawnList = new List<GameObject>();
    bool wave1 = true;
    bool waveStart = false;


    // Start is called before the first frame update
    void Start()
    {
        spawnList.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoints"));
    }

    // Update is called once per frame
    void Update()
    {
        if(wave1 && !waveStart)
        {
            StartCoroutine(StartSpawning(wave1, 10f));
        }

        
    }

    public IEnumerator StartSpawning(bool wave, float waitTime)
    {
        waveStart = true;
        while(wave)
        {
            yield return new WaitForSeconds(waitTime);
            int random = (Random.Range(0,spawnList.Count));
            
            GameObject refPlante = Instantiate(prefabPlante, spawnList[random].GetComponent<Transform>().position, Quaternion.identity);
            spawnList.RemoveAt(random);
        }

    }
}
