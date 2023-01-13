using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    public CharacterController controller;
    public Vector3 playerVelocity;
    public Vector3 move;
    public bool groundedPlayer;
    public float playerSpeed;
    public float actualSpeed;
    public float gravityValue = -9.81f;

    public GameObject skin;

    public GameObject waterArea;
    public GameObject waterJar;

    public GameObject digArea;
    public GameObject digeffect;
    public GameObject WalkEffect;

    public GameObject FlamerEffect;

    public int HP = 3;
    public bool iswalking = false;
    public bool isDead = false;
    public bool isSlow = false;
    public bool isStop = false;
    public bool isDashing = false;
    public bool HasDigging = false;
    public int DigTimer;

    public bool flamingMode = false;

    public Animator animator;

    public RawImage image1;
    public RawImage image2;
    public RawImage image3;

    public Texture plein;
    public Texture vide;

    public GameObject perso1;
    public GameObject perso2;


    private void Start()
    {
        
    }

    void Update()
    {
        //
        //Tant que le bouton gauche de la souris est enfonc�
        if (Input.GetMouseButton(0) && isDashing == false && flamingMode == false)
        {
            //Le joueur arrose
            waterArea.SetActive(true);
            waterJar.SetActive(true);
            animator.SetBool("IsWater", true);
            isSlow = true;
        }
        else
        {
            //Sinon, il n'arrose pas
            waterArea.SetActive(false);
            waterJar.SetActive(false);
            animator.SetBool("IsWater", false);
            isSlow = false;
        }
        //Tant que le bouton gauche de la souris est enfonc�
        if (Input.GetMouseButton(1) && isDashing == false && HasDigging == false)
        {
            //Le joueur Dig
            digeffect.SetActive(true);
            isStop = true;
            Invoke("DigAction", 1f);
            animator.SetBool("isDig", true);
        }
        else if (isStop == true && isDashing == false)
        {
            //Sinon, il n'arrose pas
            digeffect.SetActive(false);
            digArea.SetActive(false);
            Invoke("IsDashingDowntime", 0.5f);
            animator.SetBool("isDig", false);
        }

        if (Input.GetMouseButtonUp(1) && HasDigging == false && isDashing == false)
        {
            HasDigging = true;
            DigTimer = 10;
            InvokeRepeating("TimerTick", 0f, 1f);
        }
        if(DigTimer <= 0)
        {
            HasDigging = false;
            CancelInvoke("TimerTick");
        }

        if (Input.GetKeyDown("space") && isDashing == false)
        {
            animator.SetTrigger("Dash");
            isSlow = false;
            isStop = false;
            isDashing = true;
            Invoke("IsDashing", 0.5f);

        }

        if (isSlow == false)
        {
            actualSpeed = playerSpeed;
        }
        else
        {
            actualSpeed = playerSpeed / 2;
        }

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y <= 0)
        {
            playerVelocity.y = 0f;
        }

        if (isDead == false && isStop == false)
        {
            if (isDashing == false && isStop == false)
            {
                if (flamingMode == false) {
                    Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    controller.Move(move * Time.deltaTime * actualSpeed);

                    if (move != Vector3.zero)
                    {
                        gameObject.transform.forward = move;
                        animator.SetBool("IsWalk", true);
                        if (iswalking == false)
                        {
                            GameObject walkEffect = Instantiate(WalkEffect, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
                            Invoke("WalkAction", 1f / actualSpeed);
                            iswalking = true;
                        }
                    }
                    else
                    {
                        animator.SetBool("IsWalk", false);
                    }

                    playerVelocity.y += gravityValue * Time.deltaTime;
                    controller.Move(playerVelocity * Time.deltaTime);
                }

                var mouse = Input.mousePosition;
                mouse.z = 10;
                mouse = Camera.main.ScreenToWorldPoint(mouse);
                skin.transform.LookAt(new Vector3(mouse.x, this.transform.position.y, mouse.z));
            }
            if (isDashing == true && flamingMode == false)
            {
                Vector3 moveDirection = skin.transform.forward * 2.5f;
                controller.Move(moveDirection * Time.deltaTime * actualSpeed);
                animator.SetBool("IsWalk", false);
                if (iswalking == false)
                {
                    GameObject walkEffect = Instantiate(WalkEffect, this.GetComponent<Transform>().position, this.GetComponent<Transform>().rotation);
                    Invoke("WalkAction", 0.5f / actualSpeed);
                    iswalking = true;
                }

            }
            if (flamingMode == true)
            {
                animator.SetBool("IsFire", true);
                FlamerEffect.SetActive(true);

            }
            else
            {
                animator.SetBool("IsFire", false);
                FlamerEffect.SetActive(false);
            }
        }

        if (HP <= 0 && isDead == false)
        {
            Debug.Log("player is dead - GameOver");
            isDead = true;
        }
        switch (HP)
        {
            case 1:
                image1.texture = plein;
                image2.texture = vide;
                image3.texture = vide;

                break;
            case 2:
                image1.texture = plein;
                image2.texture = plein;
                image3.texture = vide;
                break;
            case 3:
                image1.texture = plein;
                image2.texture = plein;
                image3.texture = plein;
                break;
            default:
                image1.texture = vide;
                image2.texture = vide;
                image3.texture = vide;
                break;
        }
    }
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Projectile")
        {
            isStop = true;
            Invoke("IsDashingDowntime", 0.5f);
            Debug.Log("je hit qqchose");

            HP -= 1;
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "FireBuff")
        {
            Invoke("IsFlammingTime", 4f);
            GameObject lesSons = GameObject.FindGameObjectWithTag("sons");
            AudioClip lanceFlame = lesSons.GetComponent<sonsScript>().sons[10];
            gameObject.GetComponent<AudioSource>().PlayOneShot(lanceFlame);
            Destroy(collider.gameObject);
        }
        if (collider.gameObject.tag == "HPBuff")
        {
            if(HP < 3)
            {
                HP += 1;
            }
            Destroy(collider.gameObject);
        }
    }
    void DigAction()
    {
        if (Input.GetMouseButton(1))
        {
            digArea.SetActive(true);
        }
        else
        {
            digArea.SetActive(false);
        }
    }
    void WalkAction()
    {
        iswalking = false;
    }
    void IsDashing()
    {
        isDashing = false;
        isStop = true;
    }
    void IsDashingDowntime()
    {
        isStop = false;
    }
    void IsFlammingTime()
    {
        Invoke("FlammingDone", 3.8f);
        flamingMode = true;
    }
    void FlammingDone()
    {
        flamingMode = false;
    }
    void TimerTick()
    {
        if(DigTimer >= 0){
            DigTimer = DigTimer - 1;
        }
    }
}
