using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AngelFollow : MonoBehaviour
{
    private GameObject player;
    public IsInPlayerVision PlayerVision;
    private NavMeshAgent agent;
    public ConeCollider VisionCollider;

    private void Awake()
    {
        player = GameObject.FindWithTag("player");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (!PlayerVision.Value)
        {
            if(VisionCollider.Colliding)
            {
                if (VisionCollider.Other.CompareTag("player"))
                {
                    // player cant see angel, but angel can see player
                    agent.SetDestination(player.transform.position);
                    agent.isStopped = false;
                }
                else
                {
                    agent.isStopped = true;
                }
            }
            else
            {
                agent.isStopped = true;
            }
        } 
        else
        {
            agent.isStopped = true;
        }
    }
}
