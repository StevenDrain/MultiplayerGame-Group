using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelScript : MonoBehaviour
{
   private bool playerOneCollided = false;
    private bool playerTwoCollided = false;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerOne")
        {
            playerOneCollided = true;
        }
        else if (other.gameObject.tag == "PlayerTwo")
        {
            playerTwoCollided = true;
        }

        if (playerOneCollided && playerTwoCollided)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "PlayerOne")
        {
            playerOneCollided = false;
        }
        else if (other.gameObject.tag == "PlayerTwo")
        {
            playerTwoCollided = false;
        }
    }
}
