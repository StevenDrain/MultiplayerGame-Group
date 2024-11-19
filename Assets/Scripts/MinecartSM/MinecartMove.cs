using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MinecartMove : MinecartState
{
    private List<Transform> waypoints;
    private MinecartStateController msc;
    private NavMeshAgent navMeshAgent;
    private int currentWaypointIndex = 0;

    public MinecartMove(MinecartStateController msc, List<Transform> waypoints) : base(msc)
    {
        this.msc = msc;
        this.waypoints = waypoints;
        this.navMeshAgent = msc.GetComponent<NavMeshAgent>();
        this.navMeshAgent.updateRotation = false;
    }

    public override void OnStateEnter()
    {
        navMeshAgent.enabled = true;
        MoveToNextWaypoint();
    }

    public override void Act()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
        {
            MoveToNextWaypoint();
        }
    }

    public override void CheckTransitions()
    {
        // always in this state
    }

    private void MoveToNextWaypoint()
    {
        if (waypoints.Count < 2)
        {
            return;
        }

        // Alternate between the two waypoints
        currentWaypointIndex = (currentWaypointIndex + 1) % 2;
        msc.currentDestination = waypoints[currentWaypointIndex];
        navMeshAgent.SetDestination(msc.currentDestination.position);
    }
}