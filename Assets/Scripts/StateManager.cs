using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State currentState;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private AttackState attackState;

    private MoveMonster moveMonster;

    private void Start()
    {
        moveMonster = GetComponent<MoveMonster>();

        if (chaseState != null && attackState != null)
        {
            chaseState.Initialize(moveMonster, attackState);
            attackState.Initialize(moveMonster, chaseState);
        }

        currentState = chaseState;
    }

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        State nextState = currentState?.RunCurrentState();

        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        currentState = nextState;
    }
}