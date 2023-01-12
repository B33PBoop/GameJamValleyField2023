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

    //elements utilisés pour l'évolution de la plante
    public float waterLevel;
    public float growth = 0.2f;
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
            waterLevel -= 0.005f;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
        }

        if(fullGrown && waterLevel>=100&& !used)
        {
            //one-time resource/score/health gain
        }

        if(waterLevel <= 0)
        {
            angry = true;
            //vfx?
        }

        //Si la plante est complètement poussée, fachée, et que sont timer entre tir est terminé
        if (fullGrown && angry && shootCD <= 0)
        {
            //la plante tire vers le joueur
            Invoke("launchProjectile", 0f);

            //puis elle doit attendre avant de tirer à nouveau
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
        if (ObjCollider.CompareTag("Water") && !angry && waterLevel <=100)
        {
            waterLevel += 0.03f;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
        }
    }
}