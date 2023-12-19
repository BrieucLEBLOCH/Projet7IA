using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    //liste des differents states
    public StateZf currentState;

    // Update is called once per frame
    void Update()
    {
        RunStatemachine();
    }

    private void RunStatemachine()
    {
        StateZf nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNexState(nextState);
        }
    }

    private void SwitchToTheNexState(StateZf nextState)
    {
        currentState = nextState;
    }


}
