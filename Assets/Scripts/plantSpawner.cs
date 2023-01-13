using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantSpawner : MonoBehaviour
{
    public List<GameObject> spawnList = new List<GameObject>();

    public bool inWave = false;
    
    public int waveNumber = 1;
    public float waveTimer;
    public float waveTimerSteps;
    
    // Scrap le Zoomout
    // public float cameraSize;
    // public float cameraSizeSteps;
    // public float maxSize;
    public float respawnTimer; 
    public float respawnTimerSteps;
    public bool startWave = true;

    public List<GameObject> prefabList = new List<GameObject>();
    

    // Start is called before the first frame update
    void Start()
    {
        spawnList.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoints"));
    }

    // Update is called once per frame
    void Update()
    {
        if(!inWave)
        {
            StartCoroutine(StartSpawning(respawnTimer));
            StartCoroutine(RoundTimer(waveTimer));
        }
    }

    public IEnumerator StartSpawning(float waitTime)
    {
        inWave = true;
        startWave = true;
        
        while(startWave && spawnList.Count > 0)
        {
            yield return new WaitForSeconds(waitTime);
            int random = (Random.Range(0,spawnList.Count));
            int randomPrefab = (Random.Range(0,prefabList.Count));
            
            GameObject refPlante = Instantiate(prefabList[randomPrefab], spawnList[random].GetComponent<Transform>().position, Quaternion.identity);
            spawnList.RemoveAt(random);
        }
    }

    public IEnumerator RoundTimer(float timer)
    {
        int currentTimer = 0;
        while(currentTimer < timer)
        {
            yield return new WaitForSeconds(1f);
            currentTimer++;
        }

        waveTimer += waveTimerSteps;
        waveNumber++;
        //Scrap le zoom de camera
        // if(waveNumber%2==0)
        // {
        //     if(cameraSize < maxSize)
        //     {
        //         cameraSize += cameraSizeSteps;
        //         StartCoroutine(CameraZoomout());
        //     }
        // }
       
        if(respawnTimer > 0.05f)
        {
            respawnTimer -= respawnTimerSteps;
        }

        else
        {
            respawnTimer = 0.05f;
        }

        startWave = false;
        
        // AddSpawns();
        yield return new WaitForSeconds(1f);
        inWave = false;
    }

    // void AddSpawns()
    // {
    //     GameObject newSpawn;
    //     List<GameObject> spawnListref = new List<GameObject>(spawnList);
        
    //     float[] distance = new float[] {-2.5f, -5, -4, -7, 2.5f, 5, 4, 7};
        
    //     if(spawnList.Count < 20)
    //     {
            
        
    //         foreach (GameObject spawn in spawnListref)
    //         {
                
                

    //             if(spawn.GetComponent<spawnsInfos>().latestSpawn)
    //             {
    //                 float posX = distance[(Random.Range(0,3))];
    //                 float posZ = distance[(Random.Range(0,3))];
    //                 newSpawn = Instantiate(spawn, spawn.transform.position + new Vector3(posX,0,posZ), Quaternion.identity); 
    //                 spawn.GetComponent<spawnsInfos>().latestSpawn = false;
    //                 spawnList.Add(newSpawn);
    //             }
    //         }
    //     }
    // }
    // Scrap le zoom
    // public IEnumerator CameraZoomout()
    // {       
    //         for (float i = mainCamera.orthographicSize; i <= cameraSize ; i += 0.05f)
    //     {
    //         mainCamera.orthographicSize = i;
    //         yield return new WaitForSeconds(0.03f);
    //     }
    // }
}
