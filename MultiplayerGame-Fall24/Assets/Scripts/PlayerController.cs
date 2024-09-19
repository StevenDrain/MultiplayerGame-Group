using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
//movement variables
    [SerializeField]private GameObject player;
    [SerializeField] private float movementSpeed, rotationSpeed;
    private Vector3 movementDirection;
    public InputActionReference movement;

//jumping variables
    private bool isJumping = false;
    [SerializeField] private float jumpPower;
    private Vector3 jumpForce;
    public InputActionReference jumping;

//get gun variables
    [SerializeField] private GameObject gun;
    private bool hasGun = false;
    private int bullets = 0;

//shooting variables
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject bulletLaunchPosition;
    private bool isShooting = false;
    public InputActionReference shooting;

    // Start is called before the first frame update
    void Start()
    {
        jumpForce = new Vector3(0, jumpPower, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerMovement();
        if (!isJumping)
        {
            PlayerJump();
        }
        else
        {
            if (player.transform.position.y < 1)
            {
                isJumping = false;
            }
        }
        if(!isShooting && hasGun && bullets > 0 && shooting.action.triggered)
        {
           ShootGun();
        }
    }
    void PlayerMovement()
    {
        movementDirection = movement.action.ReadValue<Vector2>();
        player.transform.Translate(Vector3.forward * movementDirection.y * movementSpeed * Time.deltaTime);
        player.transform.Rotate(Vector3.up * movementDirection.x * rotationSpeed * Time.deltaTime);
    }
    void PlayerJump()
    {
        if (jumping.action.triggered)
        {
            isJumping = true;
            player.GetComponent<Rigidbody>().AddForce(jumpForce, ForceMode.Impulse);
        }
    }

    public void GunPickup()
    {
        if (!hasGun)//gives you the gun if you don't have it
        {
            hasGun = true;
            gun.SetActive(true);
            bullets += 10;
            Debug.Log("Bullets: " + bullets);
        }
        else//adds bullets if you already have the gun
        {
            bullets += 10;
            Debug.Log("Bullets: " + bullets);
        }
    }
    void ShootGun()
    {
        isShooting = true;
        bullets -=1;
        Debug.Log("Bullets: " + bullets);
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.SetActive(true);
        bullet.transform.position = bulletLaunchPosition.transform.position;//makes the bullet appear at launch position
        bullet.transform.rotation = bulletLaunchPosition.transform.rotation;//makes bullet face same direction as launch position

        bullet.GetComponent<Rigidbody>().AddForce(bulletLaunchPosition.transform.up * 50, ForceMode.Impulse);
        StartCoroutine(ShootingPause());
    }

    IEnumerator ShootingPause()//makes you wait before you can shoot again
    {
        yield return new WaitForSeconds(0.5f);
        isShooting = false;
    }
}

