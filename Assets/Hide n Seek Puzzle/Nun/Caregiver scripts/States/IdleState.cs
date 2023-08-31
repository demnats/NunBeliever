using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class IdleState : State
{
    private CareGiverSM sM;
    
    public IdleState(CareGiverSM machine) : base(machine)
    {
        sM = (CareGiverSM)this.machine;   
    }
    public override void Enter()
    {
        
        base.Enter();
    }
    public override void Update()
    {
        base.Update();
        if (sM.FindPlayer())
        {
            machine.changeState(sM.chaseState);
            return;
        }
        sM.StartCoroutine(enterWalk());
        
    }
    internal IEnumerator enterWalk()
    {
        sM.setAnimation(1);
        sM.fov = 360;
        yield return new WaitForSeconds(4.5f);
        machine.changeState(((CareGiverSM)machine).searchState);
        
    }
    public override void Exit()
    {
        sM.goBackPatrol = false;
        sM.StopAllCoroutines();
        sM.setAnimation(0);
        base.Exit();    
    }

}
