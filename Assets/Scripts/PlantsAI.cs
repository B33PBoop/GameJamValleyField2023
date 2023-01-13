using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class PlantsAI : MonoBehaviour
{
    //le hero
    private GameObject player;

    //element pour que l'enemi envoie des projectiles
    public GameObject projectile;
    public GameObject projectileSpawn;
    public float shootCD = 0;

    //elements utilises pour l'evolution de la plante
    public float waterLevel;
    public float growth = 0.2f;
    public float waterDrainSpeed = 0.0025f;
    public bool fullGrown = false;
    public bool angry = false;
    public bool used = false;

    public bool trackPlayer = true;
    public GameObject plant;
    public GameObject plantUI;
    public GameObject plantProgressBar;

    public GameObject particules;
    public GameObject Skin;
    public Material BurnMat;
    public bool IsBurn = false;


    //public GameObject AlignPosition;
    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 0.5f;
        plantProgressBar.GetComponent<Slider>().value = waterLevel;
        player = GameObject.FindGameObjectWithTag("Player");
        //plantUI.transform.LookAt(AlignPosition.transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!IsBurn)
        {
            Vector3 targetPostition = new Vector3(player.transform.position.x,
            this.transform.position.y,
            player.transform.position.z);

            if (angry && trackPlayer)
            {
                this.transform.LookAt(targetPostition);
            }



            if (growth < 1 && !fullGrown && gameObject.tag != "Boss")
            {
                growth += 0.005f;
                plant.transform.localScale = new Vector3(growth, growth, growth);
            }
            
            else if(growth < 2.5 && !fullGrown && gameObject.tag == "Boss") 
            {
                growth+= 0.005f;
                plant.transform.localScale = new Vector3(growth,(0.6f*growth),growth);
            }
            
            else
            {
                fullGrown = true;
            }

            if (fullGrown && waterLevel >= 0)
            {
                waterLevel -= waterDrainSpeed;
                plantProgressBar.GetComponent<Slider>().value = waterLevel;
                // Skin.GetComponent<Renderer>().material.color = new Color(waterLevel*1/255,Skin.GetComponent<Renderer>().material.color.g,Skin.GetComponent<Renderer>().material.color.b);
            }

            if (fullGrown && waterLevel >= 1 && !used)
            {
                //one-time resource/score/health gain
                //GameObject HPBuff = Instantiate(prefabPlante, spawnList[random].GetComponent<Transform>().position, Quaternion.identity);
            }

            if (waterLevel <= 0)
            {
                angry = true;
                particules.SetActive(true);
                //vfx?
            }

            //Si la plante est compl�tement pouss�e, fach�e, et que sont timer entre tir est termin�
            if (fullGrown && angry && shootCD <= 0 && trackPlayer)
            {
                //la plante tire vers le joueur
                launchProjectile();

                //puis elle doit attendre avant de tirer � nouveau
                shootCD = 1f;
            }

            shootCD -= 0.01f;
        }
        
    }

    public void launchProjectile()
    {
        gameObject.GetComponentInChildren<Animator>().SetBool("Tire",true);
    }

    private void OnTriggerStay(Collider ObjCollider)
    {
        //Si une plante rentre dans l'aire d'arrosage
        if (ObjCollider.gameObject.tag == "Water" && !angry && waterLevel <=1.5 )
        {
            waterLevel += waterDrainSpeed*2.5f;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
        }
        if (ObjCollider.gameObject.tag == "Fire" && !IsBurn)
        {
            Invoke("GotBurnt", 1f);
            IsBurn = true;
            Skin.GetComponent<SkinnedMeshRenderer>().material = BurnMat;
        };
        if (ObjCollider.gameObject.tag == "Dig" && !IsBurn)
        {
            Invoke("GotBurnt", 1f);
            IsBurn = true;
            Skin.GetComponent<SkinnedMeshRenderer>().material = BurnMat;
        };
    }
    void GotBurnt()
    {
        Destroy(this.gameObject);
    }
}