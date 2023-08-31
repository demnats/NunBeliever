using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class ChaseState : State
{
    // Start is called before the first frame update
    private CareGiverSM sM;
    private GameObject player;
    AudioSource audioSource;
    public ChaseState(CareGiverSM stateMachine) : base(stateMachine)
    {
        sM = (CareGiverSM)this.machine;
        player = GameObject.FindGameObjectWithTag("Player");
        audioSource = GameObject.FindGameObjectWithTag("Nun").GetComponent<AudioSource>();
        
    }
    public override void Enter()
    {
        base.Enter();
        audioSource.Play();
    }
    public override void Update()
    {
        base.Update();
        followPlayer();
        sM.FindPlayer();
       

        if (sM.playerCaught)
        {
           
            machine.changeState(sM.catchState);
            return;
        }
       else if (!sM.FindPlayer())
        {
            sM.fov = 180;
            float t = 10f;

            while (t > 0 && !HideMechanic.hiding)
            {
                t -= 0.1f;
                return;
            }
            machine.changeState(sM.searchState);
        }
        
    }
    internal void followPlayer()
    {
        sM.agent.destination = player.transform.position;
    }
    public override void Exit()
    {
        base.Exit();
    }

}
