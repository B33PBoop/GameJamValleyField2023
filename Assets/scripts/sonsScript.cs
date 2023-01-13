using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonsScript : MonoBehaviour
{
    /*
     * --- ORDRE DU TABLEAU --- *
    0 - themeMusique
    1 - Ambiance
    2 - arrosage
    3 - cactus
    4 - cloche
    5 - feu
    6 - joueurHit1
    7 - joueurHit2
    8 - planteMechante
    9 - tournesol
    */
    public AudioClip[] sons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
     * --- OÙ VONT LES SONS --- *
     
        themeMusique: play on awake sur empty game object

        Ambiance: play on awake sur empty game object

        arrosage: play on awake sur water collider

        cactus: play on awake sur projectile

        tournesol: play on awake sur laser

        cloche: PlantAI: if(fullGrown)
        {
            waterLevel -= waterDrainSpeed;
            plantProgressBar.GetComponent<Slider>().value = waterLevel;
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip cloche = lesSons.GetComponent<sonsScript>().sons[4];
            lesSons.GetComponent<AudioSource>().PlayOneShot(cloche);
        }


        joueurHit1-2: PlayerController: if (collider.gameObject.tag == "Projectile")
        {
            HP -= 1;
            int hit = UnityEngine.Random.Range(6, 7);
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip plrHit = lesSons.GetComponent<sonsScript>().sons[hit];
            lesSons.GetComponent<AudioSource>().PlayOneShot(plrHit);
        }


        planteMechante: PlantAI: if(waterLevel <= 0)
        {
            angry = true;
            //vfx?
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip angry = lesSons.GetComponent<sonsScript>().sons[8];
            lesSons.GetComponent<AudioSource>().PlayOneShot(angry);
        }


        feu: PlantAI: private void OnTriggerStay(Collider ObjCollider)
        {
            //Si une plante rentre dans l'aire d'arrosage
            if (ObjCollider.gameObject.tag == "Water" && !angry && waterLevel <=1 )
            {
                waterLevel += waterDrainSpeed*2.5f;
                plantProgressBar.GetComponent<Slider>().value = waterLevel;
            }
            if (ObjCollider.gameObject.tag == "fire")
            {
                GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
                AudioClip feu = lesSons.GetComponent<sonsScript>().sons[5];
                lesSons.GetComponent<AudioSource>().PlayOneShot(feu);
                Destroy(gameObject, 1.5f);
            }
        }
     
     */
}
