using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchState : State
{
    private CareGiverSM sM;

    [Header("Pathfinding")]
    [HideInInspector] internal int currentWaypoint = 0;
    [HideInInspector] internal bool reachedWaypoint;
    [HideInInspector] internal Transform nextWaypoint;
    [HideInInspector] private GameObject[] waypointList;
    public SearchState(CareGiverSM machine) : base(machine)
    {
        sM = (CareGiverSM)this.machine;
        waypointList = GameObject.FindGameObjectsWithTag("Waypoints");
    }
    public override void Enter()
    {
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        sM.setAnimation(0);
        Patrol();
        sM.FindPlayer();

        if (sM.FindPlayer())
        {
            machine.changeState(((CareGiverSM)machine).chaseState);
            return;
        }
        if (reachedWaypoint)
        {
            machine.changeState(sM.idleState);
            reachedWaypoint = false;
            return;
        }
        

    }
    public override void Exit()
    {
        base.Exit();
    }
    internal void Patrol()
    {
        //Moving towards the destination
        sM.agent.destination = waypointList[currentWaypoint].transform.position;

        //assigns the first waypoint.
        if (nextWaypoint == null)
        {
            nextWaypoint = waypointList[currentWaypoint].transform;
        }

        //When the agent reaches the waypoint it will move on to the next
        if (sM.transform.position.x == waypointList[currentWaypoint].transform.position.x &&
           sM.transform.position.z == waypointList[currentWaypoint].transform.position.z)
        {
            Vector3 direction = (waypointList[currentWaypoint].transform.position - sM.transform.position).normalized;
            sM.transform.rotation = Quaternion.LookRotation(direction);

            if (currentWaypoint < waypointList.Length - 1)
            {
                currentWaypoint++;
                nextWaypoint = waypointList[currentWaypoint].transform;
            }
            else
            {
                currentWaypoint = 0;
                nextWaypoint = null;
            }
            reachedWaypoint = true;

        }
    }
}
