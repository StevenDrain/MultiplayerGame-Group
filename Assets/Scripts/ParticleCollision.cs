using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    public bool resetplayerPos;
    public GameObject respawnPoint;
    private CharacterController characterController;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        characterController = GetComponent<CharacterController>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerOne")
        {
            Debug.Log("Death1");
            ResetLevel();
        }
        else if (other.tag == "PlayerTwo")
        {
            Debug.Log("Death2");
            ResetLevel();
        }
    }

    void ResetLevel()
    {
        if (resetplayerPos == true)
        {
            Debug.Log("Resetting player position");
            characterController.enabled = false; 
            transform.position = respawnPoint.transform.position; 
            characterController.enabled = true; 
        }
        resetplayerPos = false;
    }
}