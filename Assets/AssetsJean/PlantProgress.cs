using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlantProgress : MonoBehaviour
{

    public float progress;
    public GameObject plant;
    public GameObject plantUI;

    // Start is called before the first frame update
    void Start()
    {
        progress = 0.1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(progress < 1) 
        {
            progress = progress + 0.001f;
            plant.transform.localScale = new Vector3(progress, progress, progress);
            plantUI.GetComponent<Slider>().value = progress;
        }
       
    }
}
