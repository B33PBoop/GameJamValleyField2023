using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plantSpawner : MonoBehaviour
{
    
    public GameObject prefabPlante;
    public List<GameObject> spawnList = new List<GameObject>();

    public bool inWave = false;

    public int waveNumber = 1;
    public float waveTimer;
    public float waveTimerSteps;
    public float cameraSize;
    public float cameraSizeSteps;
    public float respawnTimer; 
    public float respawnTimerSteps;
    public bool startWave = true;

    
    Camera mainCamera; 

    // Start is called before the first frame update
    void Start()
    {
        spawnList.AddRange(GameObject.FindGameObjectsWithTag("SpawnPoints"));
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
            
            GameObject refPlante = Instantiate(prefabPlante, spawnList[random].GetComponent<Transform>().position, Quaternion.identity);
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
        if(waveNumber%2==0)
        {
            cameraSize += cameraSizeSteps;
            StartCoroutine(CameraZoomout());
        }
       
        if(respawnTimer > 0.05f)
        {
            respawnTimer -= respawnTimerSteps;
        }

        else
        {
            respawnTimer = 0.05f;
        }

        startWave = false;
        
        AddSpawns();
        yield return new WaitForSeconds(1f);
        inWave = false;
    }

    void AddSpawns()
    {
        GameObject newSpawn;
        List<GameObject> spawnListref = new List<GameObject>(spawnList);
        

        foreach (GameObject spawn in spawnListref)
        {
            
            
            if(spawn.GetComponent<spawnsInfos>().latestSpawn)
            {
                if(spawn.transform.position.x >= 0)
                {
                    if(spawn.transform.position.z >= 0)
                    {
                        newSpawn = Instantiate(spawn, spawn.transform.position + new Vector3((Random.Range(-2f,2f)),0,((Random.Range(2f,2f)))), Quaternion.identity); 
                    }

                    else
                    {
                        newSpawn = Instantiate(spawn, spawn.transform.position + new Vector3((Random.Range(-2f,2f)),0,((Random.Range(-2f,2f)))), Quaternion.identity);
                    }
                }

                else
                {
                    if(spawn.transform.position.z >= 0)
                    {
                        newSpawn = Instantiate(spawn, spawn.transform.position - new Vector3((Random.Range(-2f,2f)),0,((Random.Range(-2f,2f)))), Quaternion.identity);
                    }

                    else
                    {
                        newSpawn = Instantiate(spawn, spawn.transform.position - new Vector3((Random.Range(-2f,2f)),0,((Random.Range(-2f,2f)))), Quaternion.identity);
                    }
                }
                spawn.GetComponent<spawnsInfos>().latestSpawn = false;
                spawnList.Add(newSpawn);
            }
        }
    }

    public IEnumerator CameraZoomout()
    {       
            for (float i = mainCamera.orthographicSize; i <= cameraSize ; i += 0.05f)
        {
            mainCamera.orthographicSize = i;
            yield return new WaitForSeconds(0.03f);
        }
    }
}
