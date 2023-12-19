using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //liste des differents states
    public State currentState;

    // Update is called once per frame
    void Update()
    {
        RunStatemachine();
    }

    private void RunStatemachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNexState(nextState);
        }
    }

    private void SwitchToTheNexState(State nextState)
    {
        currentState = nextState;
    }


}
