using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MovementP1 : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -20f;

    private CharacterController characterController;
    private Vector3 velocity; 

    private bool isGrounded;
    public float jumpForce = 5f; 

    //abilities
    public int levelNumber = 1;
    public bool doubleJump;

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
        
        if (isGrounded && velocity.y < 0)
        {
            doubleJump = true;
        }

        float moveInput = Input.GetAxis("Player1Move");

        // Sketchy Idea: check if movement is positive or negative and rotate left or right accordingly then just walk forward
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); // Face right
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); // Face left
        }
        
        Vector3 move = transform.forward * Mathf.Abs(moveInput) * speed;
        // End of Sketchy Idea

        if (canClimb)
        {
            float climbInput = Input.GetAxis("Vertical"); // Use "Vertical" axis for climbing
            Vector3 climbMove = new Vector3(0, climbInput * climbSpeed, 0);
            characterController.Move(climbMove * Time.deltaTime);

            // Allow the player to jump off the ladder
            if (Input.GetButtonDown("Player1Jump"))
            {
                canClimb = false;
                velocity.y = jumpForce; // Apply jump force to exit the ladder
            }

            // Allow the player to move left or right off the ladder
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
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

            if (Input.GetButtonDown("Player1Jump") && isGrounded)
            {
                velocity.y += jumpForce; 
            }
            else if (Input.GetButtonDown("Player1Jump") && doubleJump && levelNumber == 1)
            {
                velocity.y += jumpForce;
                doubleJump = false; 
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