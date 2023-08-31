using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CatchState : State
{
    private CareGiverSM sM;
    private GameObject playerSpawnPoint;
    private GameObject carry;
    private CharacterController playerCC;
    private AudioSource audioSource;   

    public CatchState(CareGiverSM stateMachine) : base(stateMachine)
    {
        sM = (CareGiverSM)this.machine;
        playerCC = sM.playerController.GetComponent<CharacterController>();
        carry = GameObject.FindGameObjectWithTag("Carry");
        playerSpawnPoint = GameObject.FindGameObjectWithTag("Spawnpoint");
        audioSource = carry.GetComponent<AudioSource>();
    }
    public override void Enter()
    {
        base.Enter();
        audioSource.Play();
    }
    public override void Update()
    {
        base.Update();
        
        sM.setAnimation(2); //grab animation
        bringingPlayerBackToSpawn();

        if (!sM.playerCaught)
        {
            machine.changeState(sM.searchState);
            
        }
    }
    public override void Exit()
    {
        sM.fov = 180;
        base.Exit();
    }
    internal bool bringingPlayerBackToSpawn()
    {
        //when the agent isn't located on the spawnpoint move towards the spawnpoint
        if (sM.transform.position.x != playerSpawnPoint.transform.position.x &&
            sM.transform.position.z != playerSpawnPoint.transform.position.z)
        {
            playerCC.enabled = false;
            sM.agent.destination = playerSpawnPoint.transform.position;
            sM.playerController.canMove = false;

            //moves the player with the agents so the agent automatically creates the path for both objects
            sM.playerController.transform.position = carry.transform.position;
            sM.playerController.playerCamera.transform.rotation = carry.transform.rotation;
           
            return true;
        }
        else
        {
            playerCC.enabled = true;
            sM.playerController.transform.position = carry.transform.position;
            sM.playerController.canMove = true;
            sM.StartCoroutine(sM.goBackToPatrol());
            return false;
        }

    }

}
