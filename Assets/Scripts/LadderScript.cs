using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{
    public GameObject player1OBJ;
    public GameObject player2OBJ;
    public Rigidbody player1RB;
    public Rigidbody player2RB;
    bool canClimbPlayer1 = false;
    bool canClimbPlayer2 = false;
    float speed = 5;

    

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject == player1OBJ)
        {
            canClimbPlayer1 = true;
            player1RB.isKinematic = true; // Set Rigidbody to kinematic
        }
        if (coll.gameObject == player2OBJ)
        {
            canClimbPlayer2 = true;
            player2RB.isKinematic = true; // Set Rigidbody to kinematic
        }
    }

    void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject == player1OBJ)
        {
            canClimbPlayer1 = false;
            player1RB.isKinematic = false; // Reset Rigidbody to non-kinematic
        }
        if (coll.gameObject == player2OBJ)
        {
            canClimbPlayer2 = false;
            player2RB.isKinematic = false; // Reset Rigidbody to non-kinematic
        }
    }

    void Update()
    {
        if (canClimbPlayer1)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Debug.Log("W");
                player1OBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
                Debug.Log("Player1 Position: " + player1OBJ.transform.position);
            }
            if (Input.GetKey(KeyCode.S))
            {
                player1OBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
                Debug.Log("Player1 Position: " + player1OBJ.transform.position);
            }
        }

        if (canClimbPlayer2)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                Debug.Log("UpArrow");
                player2OBJ.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * speed);
                Debug.Log("Player2 Position: " + player2OBJ.transform.position);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                player2OBJ.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * speed);
                Debug.Log("Player2 Position: " + player2OBJ.transform.position);
            }
        }
    }
}