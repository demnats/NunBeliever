using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    
    protected StateMachine machine;
    public State(StateMachine machine)
    {
        
        this.machine = machine;
    }

    public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }


}
