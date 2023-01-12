using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float vitesse;
    public GameObject skin;
    public GameObject cam;
    public GameObject waterArea;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float vDeplacement = Input.GetAxis("Vertical") * vitesse;
        float hDeplacement = Input.GetAxis("Horizontal") * vitesse;

        GetComponent<Rigidbody>().velocity = transform.forward * vDeplacement + transform.right * hDeplacement;

        //var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);

        //ici on dit que la variable angle est le calcule de la position de la directions en rapport avec la radiance en degré de cellle-ci dupoint de vue de notre element controlé
        //var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //enfin, on fait bouger la rotation de l'element pour rejoindre la variable angle se qui nou permet de faire suivre l'element par rapport a la sourie
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);


        //var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var mouse = Input.mousePosition;
        mouse.z = 10;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        //var angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        //skin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        skin.transform.LookAt(new Vector3(mouse.x, 1, mouse.z));

        if (Input.GetMouseButton(0))
        {
            waterArea.SetActive(true);
        }
        else
        {
            waterArea.SetActive(false);
        }
    }
}
