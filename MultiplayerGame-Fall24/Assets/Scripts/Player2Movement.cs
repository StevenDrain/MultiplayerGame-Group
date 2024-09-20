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

    private bool isGrounded;
    public float jumpForce = 5f; 

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        
        float moveInput = Input.GetAxis("Player2Move");
        Vector3 move = new Vector3(moveInput * speed, 0, 0);

        
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0; 
        }

        if (Input.GetButtonDown("Player2Jump") && isGrounded)
        {
            velocity.y += jumpForce; 
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move((move + velocity) * Time.deltaTime);
    }
}
