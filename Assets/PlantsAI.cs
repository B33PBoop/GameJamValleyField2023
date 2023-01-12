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
    private float shootCD = 0;

    //elements utilis�s pour l'�volution de la plante
    public float waterLevel;
    public float growth = 0.2f;
    public float waterDrainSpeed = 0.005f;
    public bool fullGrown = false;
    public bool angry = false;
    public bool used = false;
    public GameObject plant;
    public GameObject plantUI;
    public GameObject plantProgressBar;

    // Start is called before the first frame update
    void Start()
    {
        waterLevel = 0.5f;
        plantProgressBar.GetComponent<Slider>().value = waterLevel;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 targetPostition = new Vector3(player.transform.position.x,
        this.transform.position.y,
        player.transform.position.z);
        this.transform.LookAt(targetPostition);

        if (growth < 1 && !fullGrown)
        {
            growth += 0.005f;
            plant.transform.localScale = new Vector3(growth, growth, growth);
        } 
        else
        {
            fullGrown = true;
        }
       
        if(fullGrown)
        {
            waterLevel -= waterDrainSpeed;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
        }

        if(fullGrown && waterLevel>=1 && !used)
        {
            //one-time resource/score/health gain
            //GameObject HPBuff = Instantiate(prefabPlante, spawnList[random].GetComponent<Transform>().position, Quaternion.identity);
        }

        if(waterLevel <= 0)
        {
            angry = true;
            //vfx?
        }

        //Si la plante est compl�tement pouss�e, fach�e, et que sont timer entre tir est termin�
        if (fullGrown && angry && shootCD <= 0)
        {
            //la plante tire vers le joueur
            Invoke("launchProjectile", 0f);

            //puis elle doit attendre avant de tirer � nouveau
            shootCD = 1f;
        }

        shootCD -= 0.01f;
    }

    public void launchProjectile()
    {
        GameObject projectileClone = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
    }

    private void OnTriggerStay(Collider ObjCollider)
    {
        //Si une plante rentre dans l'aire d'arrosage
        if (ObjCollider.gameObject.tag == "Water" && !angry && waterLevel <=1 )
        {
            waterLevel += waterDrainSpeed*2.5f;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
        }
    }
}