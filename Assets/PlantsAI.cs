using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Rendering.FilterWindow;
using static UnityEngine.GraphicsBuffer;

public class PlantsAI : MonoBehaviour
{
    //le hero
    private GameObject player;

    //element pour que l'enemie envoi des projectiles
    public GameObject projectile;
    public GameObject projectileSpawn;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("launchProjectile", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 targetPostition = new Vector3(player.transform.position.x,
        this.transform.position.y,
        player.transform.position.z);
        this.transform.LookAt(targetPostition);
    }

    public void launchProjectile()
    {
        GameObject projectileClone = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
    }
}
