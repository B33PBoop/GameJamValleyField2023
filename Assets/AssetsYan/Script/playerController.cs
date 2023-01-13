using System;
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
    public GameObject digArea;

    public int HP = 3;
    private bool isDead = false;
    private bool isSlow = false;
    private bool isStop = false;

    public Animator animator;


    private void Start()
    {
        
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }

        if (isDead == false && isStop == false)
        {
            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed);

            if (move != Vector3.zero)
            {
                gameObject.transform.forward = move;
                animator.SetBool("IsWalk", true);
            }
            else
            {
                animator.SetBool("IsWalk", false);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);


            var mouse = Input.mousePosition;
            mouse.z = 10;
            mouse = Camera.main.ScreenToWorldPoint(mouse);
            //var angle = Mathf.Atan2(mouse.y, mouse.x) * Mathf.Rad2Deg;
            //skin.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            skin.transform.LookAt(new Vector3(mouse.x, this.transform.position.y, mouse.z));
        }

        //
        //Tant que le bouton gauche de la souris est enfonc�
        if (Input.GetMouseButton(0))
        {
            //Le joueur arrose
            waterArea.SetActive(true);
            animator.SetBool("IsWater", true);
        }
        else
        {
            //Sinon, il n'arrose pas
            waterArea.SetActive(false);
            animator.SetBool("IsWater", false);
        }
        //Tant que le bouton gauche de la souris est enfonc�
        if (Input.GetMouseButton(1))
        {
            //Le joueur Dig
            digArea.SetActive(true);
            isStop = true;
            animator.SetBool("IsFire", true);
        }
        else
        {
            //Sinon, il n'arrose pas
            digArea.SetActive(false);
            isStop = false;
            animator.SetBool("IsFire", false);
        }

        if (HP <= 0 && isDead == false)
        {
            Debug.Log("player is dead - GameOver");
            isDead = true;
        }
        switch (HP)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            default:
                break;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            HP -= 1;
            int hit = UnityEngine.Random.Range(6, 7);
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip plrHit = lesSons.GetComponent<sonsScript>().sons[hit];
            gameObject.GetComponent<AudioSource>().PlayOneShot(plrHit);
        }
        if (collider.gameObject.tag == "lance-flame")
        {
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip lanceFlame = lesSons.GetComponent<sonsScript>().sons[10];
            gameObject.GetComponent<AudioSource>().PlayOneShot(lanceFlame);
        }
    }
}
