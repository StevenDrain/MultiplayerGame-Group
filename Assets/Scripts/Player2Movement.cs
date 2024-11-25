using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class MovementP2 : MonoBehaviour
{
    public float speed = 3f;
    public float gravity = -20f;

    private CharacterController characterController;
    private Vector3 velocity;

    private bool isGrounded;
    public float jumpForce = 5f;

    private bool canClimb = false;
    public float climbSpeed = 3f;

    public float shieldDuration = 2000f;
    public GameObject shield;
    private bool isActive;
    private bool shieldActive;

    

    public bool canBreak;

    private Scene scene;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        scene = SceneManager.GetActiveScene();
    }


    void Start()
    {
        shield.SetActive(false);
        isActive = shield.activeSelf;
    }

    void Update()
    {
        isGrounded = characterController.isGrounded;

        float moveInput = Input.GetAxis("Player2Move");

        if (moveInput > 0)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (moveInput < 0)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }

        Vector3 move = transform.forward * Mathf.Abs(moveInput) * speed;

        if (canClimb)
        {
            float climbInput = Input.GetAxis("Vertical");
            Vector3 climbMove = new Vector3(0, climbInput * climbSpeed, 0);
            characterController.Move(climbMove * Time.deltaTime);

            if (Input.GetButtonDown("Player2Jump"))
            {
                canClimb = false;
                velocity.y = jumpForce;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                canClimb = false;
                velocity.y = 0;
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

        if (shieldActive)
        {
            shieldDuration -= 1;
            
        }

        if (Input.GetButtonDown("Player2Ability") && shieldDuration > 0f)
        {
            isActive = !isActive;
            shield.SetActive(isActive);
            shieldActive = !shieldActive;
        }

        if (shieldDuration < 2000 && !shieldActive)
        {
            shieldDuration += 1;
        }

        if (shieldDuration <= 0)
        {
            shield.SetActive(false);
            shieldActive = false;
            
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ladder"))
        {
            canClimb = true;
            velocity = Vector3.zero;
        }
        if (other.CompareTag("Death"))
        {
            ResetLevel();
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

    void ResetLevel()
    {
        SceneManager.LoadScene(scene.name);
    }
}