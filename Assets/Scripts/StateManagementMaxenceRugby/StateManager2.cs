using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager2 : MonoBehaviour
{
    //liste des differents states
    public State2 currentState;

    // Update is called once per frame
    void Update()
    {
        RunStatemachine();
    }

    private void RunStatemachine()
    {
        State2 nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNexState(nextState);
        }
    }

    private void SwitchToTheNexState(State2 nextState)
    {
        currentState = nextState;
    }


}
