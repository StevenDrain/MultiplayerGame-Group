using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleCollision : MonoBehaviour
{
    public ParticleSystem part;
    public GameObject respawnPoint;
    public CharacterController Player1characterController;
    public CharacterController Player2characterController;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.tag == "PlayerOne")
        {
            Debug.Log("Death1");
            ResetLevelPlayer1();
        }
        else if (other.tag == "PlayerTwo")
        {
            Debug.Log("Death2");
            ResetLevelPlayer2();
        }
    }

    void ResetLevelPlayer1()
    {
        if (respawnPoint != null)
        {
            Player1characterController.enabled = false;
            Player1characterController.transform.position = respawnPoint.transform.position;
            Player1characterController.enabled = true;
        }
        else
        {
            Debug.LogError("Respawn point is not assigned.");
        }
    }

    void ResetLevelPlayer2()
    {
        if (respawnPoint != null)
        {
            Player2characterController.enabled = false;
            Player2characterController.transform.position = respawnPoint.transform.position;
            Player2characterController.enabled = true;
        }
        else
        {
            Debug.LogError("Respawn point is not assigned.");
        }
    }
}