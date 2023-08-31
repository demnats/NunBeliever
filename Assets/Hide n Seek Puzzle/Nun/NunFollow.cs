using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NunFollow : MonoBehaviour
{
    public GameObject Player;
    public NavMeshAgent Agent;
    public bool MustBeVisible;

    [HideInInspector]
    private int awareness;
    //public int Awareness
    //{
    //    get { return awareness; }
    //    set { if (value <= MaxAwareness) awareness = value; AwarenessDisplay.UpdateAwareness(value); }
    //}
    public int MaxAwareness;
    public int HuntInterval;
    private float huntTimer;
    public int[] HuntChance;

    public Vector3 previousDestination;
    public int wanderingTime = 0;
    public int wanderingTreshhold = 1000;
    public int wanderDistance = 12;
    public bool wandering = true; //Later StateMachine

    //public AwarenessDisplay AwarenessDisplay;

    // Update is called once per frame
    void Update()
    {
        //if (huntTimer > HuntInterval)
        //{
        //    huntTimer = huntTimer - HuntInterval;
        //    if (Random.Range(0, 100) < HuntChance[Awareness])
        //    {
        //        Agent.destination = Player.transform.position;
        //    }
        //}

        //huntTimer += Time.deltaTime;

    }

}
