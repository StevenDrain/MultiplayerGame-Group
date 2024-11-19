using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinecartStateController : MonoBehaviour
{
    public MinecartState currentState;
    public Transform currentDestination;
    public List<Transform> waypoints = new List<Transform>();

    // Start is called before the first frame update
    void Start()
    {
        if (waypoints.Count < 2)
        {
            Debug.LogError("Please assign at least two waypoints.");
            return;
        }

        currentDestination = waypoints[0];
        SetState(new MinecartMove(this, waypoints));
    }

    public Transform randomDestination()
    {
        if (waypoints.Count > 0)
        {
            int rd = Random.Range(0, waypoints.Count);
            return waypoints[rd];
        }
        return null;
    }

    public void SetState(MinecartState state)
    {
        if (currentState != null)
        {
            currentState.OnStateExit();
        }
        currentState = state;
        if (currentState != null)
        {
            currentState.OnStateEnter();
            Debug.Log("Current State: " + currentState.GetType().Name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Act();
            currentState.CheckTransitions();
        }
    }
}