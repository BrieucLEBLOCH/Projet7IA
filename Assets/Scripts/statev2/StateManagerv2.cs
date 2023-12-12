using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManagerv2 : MonoBehaviour
{
    public State currentState;
    // Update is called once per frame
    void Update()
    {
        RunstateMachine();
    }

    private void RunstateMachine()
    {
        State nextstate = currentState?.RunCurrentState();

        if (nextstate != null)
        {
            SwitchToTheNextState(nextstate);
        }
    }

    private void SwitchToTheNextState(State nextstate)
    {
        currentState = nextstate;
    }
}
