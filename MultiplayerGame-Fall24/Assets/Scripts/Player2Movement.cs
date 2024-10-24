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

    // Ladder climbing
    private bool canClimb = false;
    public float climbSpeed = 3f;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        
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

        if (canClimb)
        {
            float climbInput = Input.GetAxis("Vertical"); // Use "Vertical" axis for climbing
            Vector3 climbMove = new Vector3(0, climbInput * climbSpeed, 0);
            characterController.Move(climbMove * Time.deltaTime);

            // Allow the player to jump off the ladder
            if (Input.GetButtonDown("Player2Jump"))
            {
                canClimb = false;
                velocity.y = jumpForce; // Apply jump force to exit the ladder
            }

            // Allow the player to move left or right off the ladder
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                canClimb = false;
                velocity.y = 0; // Reset vertical velocity when exiting the ladder
            }
        }
        else
        {
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

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = true;
            velocity = Vector3.zero; // Reset velocity when starting to climb
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = false;
            velocity.y = 0; // Reset vertical velocity when exiting the ladder
        }
    }
}