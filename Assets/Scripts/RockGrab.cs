using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGrab : MonoBehaviour
{
    public float grabDistance = 2f;
    public Transform leftGrabPosition;
    public Transform rightGrabPosition;

    private GameObject grabbedRock = null;
    private Rigidbody rockRb;
    private Collider rockCollider;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (grabbedRock == null)
            {
                TryGrabRock();
            }
        }
        else if (grabbedRock != null) //
        {
            DropRock();
        }
    }

    void TryGrabRock()
    {
        GameObject[] rocks = GameObject.FindGameObjectsWithTag("Rock");

        foreach (GameObject rock in rocks)
        {
            float distanceToRock = Vector3.Distance(transform.position, rock.transform.position);

            if (distanceToRock <= grabDistance)
            {
                grabbedRock = rock;
                rockRb = grabbedRock.GetComponent<Rigidbody>();
                rockCollider = grabbedRock.GetComponent<Collider>();

                if (rockRb != null)
                {
                    rockRb.isKinematic = true;
                }
                if (rockCollider != null)
                {
                    Physics.IgnoreCollision(rockCollider, GetComponent<Collider>(), true);
                }

                // Determine the target position based on player orientation and rock�s initial position
                bool isFacingRight = transform.rotation.eulerAngles.y == 90;
                Vector3 directionToRock = rock.transform.position - transform.position;
                bool rockIsOnRight = Vector3.Dot(transform.right, directionToRock) > 0;
                Transform targetPosition = (isFacingRight == rockIsOnRight) ? rightGrabPosition : leftGrabPosition;

                // Attach rock to the chosen side
                grabbedRock.transform.position = targetPosition.position;
                grabbedRock.transform.SetParent(targetPosition);
                break;
            }
        }
    }

    void DropRock()
    {
        if (grabbedRock != null)
        {
            if (rockRb != null)
            {
                rockRb.isKinematic = false;
                // Remove the line that unfreezes the positions
                // rockRb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            if (rockCollider != null)
            {
                Physics.IgnoreCollision(rockCollider, GetComponent<Collider>(), false);
            }

            grabbedRock.transform.SetParent(null);
            grabbedRock = null;
            rockRb = null;
            rockCollider = null;
        }
    }
}
