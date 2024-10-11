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

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
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

        velocity.y += gravity * Time.deltaTime;
        characterController.Move((move + velocity) * Time.deltaTime);
    }
}
