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

    //wall break
    public bool canBreak;


    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        canBreak = true;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;
        
        if (isGrounded && velocity.y < 0)
        {
            doubleJump = true;
        }

        float moveInput = Input.GetAxis("Player1Move");
        

        //Sketchy Idea: check if movement is postivie or negative and rotate left or right accordingly then just walk forward
        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0); // Face right
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0); // Face left
        }
        
        Vector3 move = transform.forward * Mathf.Abs(moveInput) * speed;
        //End of Sketchy Idea


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
