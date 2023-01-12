using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;

    public GameObject skin;

    public GameObject waterArea;

    private void Start()
    {
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);


        var mouse = Input.mousePosition;
        mouse.z = 10;
        mouse = Camera.main.ScreenToWorldPoint(mouse);
        //var angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
        //skin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        skin.transform.LookAt(new Vector3(mouse.x, this.transform.position.y, mouse.z));

        //Tant que le bouton gauche de la souris est enfoncé
        if (Input.GetMouseButton(0))
        {
            //Le joueur arrose
            waterArea.SetActive(true);
        }
        else
        {
            //Sinon, il n'arrose pas
            waterArea.SetActive(false);
        }

    }
}
