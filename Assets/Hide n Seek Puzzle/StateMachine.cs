using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    internal State currentState;

    
    void Start()
    {
        if(currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(currentState);
        if(currentState != null)
        {
            currentState.Update();
        }
    }
    public void changeState(State nextState)
    {
        currentState.Exit();
      
        currentState = nextState;
        nextState.Enter();
    }
    internal virtual void setState(State thisState)
    {
        currentState = thisState;
    }
   
    
}
