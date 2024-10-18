using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementP2 : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -20f;

    private CharacterController characterController;
    private Vector3 velocity;

    public bool isGrounded;
    public float jumpForce = 5f;

    //SHIELD
    public float shieldDuration = 500f;
    public GameObject shield;
    private bool isActive;
    private bool shieldActive;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }


    void Start()
    {

        shield.SetActive(false);
        isActive = shield.activeSelf;
    }




    void Update()
    {
        if (isGrounded != true)
        {
            isGrounded = characterController.isGrounded;
        }

        float moveInput = Input.GetAxis("Player2Move");

        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); // Face right
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); // Face left
        }

        Vector3 move = transform.forward * Mathf.Abs(moveInput) * speed;


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0;
        }

        if (Input.GetButtonDown("Player2Jump") && isGrounded)
        {
            velocity.y += jumpForce;
            isGrounded = false;
        }

        if(shieldActive == true)
        {
            shieldDuration -= 1;
        }

        if (Input.GetButtonDown("Player2Ability") && shieldDuration > 0f)
        {
            isActive = !isActive;
            shield.SetActive(isActive);
            shieldActive = !shieldActive;
        }

        if (shieldDuration < 500 && shieldActive == false)
        {
            shieldDuration += 1;
            
        }

        if (shieldDuration <= 0)
        {
            shield.SetActive(false);
            shieldActive = false;
        }



        velocity.y += gravity * Time.deltaTime;
        characterController.Move((move + velocity) * Time.deltaTime);
    }
}
