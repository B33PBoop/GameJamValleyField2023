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
    public float progress;
    public GameObject plant;
    public GameObject plantUI;
    public GameObject plantProgressBar;

    // Start is called before the first frame update
    void Start()
    {

        progress = 0.05f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 targetPostition = new Vector3(player.transform.position.x,
        this.transform.position.y,
        player.transform.position.z);
        this.transform.LookAt(targetPostition);

        if (progress < 1)
        {
            progress += 0.001f;
            plant.transform.localScale = new Vector3(progress, progress, progress);
            plantProgressBar.GetComponent<Slider>().value = progress;
        }

        if (progress >= 1 && shootCD <= 0)
        {
            Invoke("launchProjectile", 0f);
            shootCD = 1f;
        }

        shootCD -= 0.01f;
    }

    public void launchProjectile()
    {
        GameObject projectileClone = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
    }
}
