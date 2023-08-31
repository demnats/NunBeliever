using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class CareGiverSM : StateMachine
{
    [HideInInspector] public IdleState idleState;
    [HideInInspector] public SearchState searchState;
    [HideInInspector] public ChaseState chaseState;
    [HideInInspector] public CatchState catchState;
    [HideInInspector] internal NavMeshAgent agent;

    [Header("Catching the player")]
    [SerializeField] internal PlayerController playerController;
    [SerializeField] private float grabLength = 2f;
    [SerializeField] internal float fov = 90;
 
    internal bool playerCaught;
    internal bool playerSeen;
    internal bool goBackPatrol;

    Animator animator;

    private void Awake()
    {
        idleState = new IdleState(this);
        searchState = new SearchState(this);
        catchState = new CatchState(this);
        chaseState = new ChaseState(this);
    }
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        setState(idleState);
    }
    internal void setAnimation(int animationState)
    {
        animator.SetInteger("animation", animationState);
    }


    internal IEnumerator goBackToPatrol()
    {
        goBackPatrol = true;
        playerCaught = false;

        yield return new WaitForSeconds(5);
        goBackPatrol = false;
    }

    internal bool FindPlayer()
    {
        var distance = playerController.transform.position - transform.position;

        //Calculates the angle from which the agent can see the player
        if (Vector3.Angle(transform.forward, distance.normalized) < fov / 2)
        {
            float length = (playerController.transform.position - transform.position).magnitude;
           
            //Calculates the agents raycast
            if (Physics.Raycast(transform.position, distance.normalized, out RaycastHit hitInfo, length + 1))
            {
                //checks if the raycast hits the player and checks if the agent isnt coming back from the spawnpoint
                if (hitInfo.collider.CompareTag("Player") && !goBackPatrol && !HideMechanic.hiding)
                {
             
                //Debug.Log(hitInfo.collider);
                    //grabs the player and puts him back to the spawnpoint
                    if (hitInfo.distance <= grabLength)
                    {
                        playerCaught = true;
                    }
                    return true;
                }
                else return false;
            }
            else return false;
        }
        else return false;
    }

}
