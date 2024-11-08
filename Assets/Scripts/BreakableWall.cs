using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{

    private bool isBroken = false;
     public float detectionRange = 2.0f; // Range to detect the player

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightAlt))
        {
           MovementP2 player = FindPlayerInRange();
           if(player != null)
           {

                Debug.Log("Player canBreak value: " + player.canBreak);
                if(player.canBreak)
                {
                    BreakWall(player.gameObject);
                }
                else
                {
                    Debug.Log("Player is not allowed to break this wall");
                }
           }
        }
    }

    public void BreakWall(GameObject player)
    {
        if(isBroken)
        {
            Debug.Log("already brokem");
            return;

        }

        Destroy(this.gameObject);
        isBroken = true;

        Debug.Log("object broken");

    }

    // Check if a player is close enough to the object
    private MovementP2 FindPlayerInRange()
    {
        // Use Physics.OverlapSphere to detect players within range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange);
        foreach (var hitCollider in hitColliders)
        {
            // Attempt to get the MovementP1 component from the hit collider
            MovementP2 player = hitCollider.GetComponent<MovementP2>();
            if (player != null)
            {
                Debug.Log("Player found within range: " + player.name);
                return player; // Player found
            }
        }

        Debug.Log("No player found within range.");
        return null; // No player found
    }

        private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
