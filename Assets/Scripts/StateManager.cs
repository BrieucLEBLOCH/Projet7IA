using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField] private State currentState;
    [SerializeField] private IdleState idleState;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private AttackState attackState;

    private MoveMonster moveMonster;

    private void Start()
    {
        moveMonster = GetComponent<MoveMonster>();

        if (idleState != null && chaseState != null && attackState != null)
        {
            idleState.Initialize(moveMonster, chaseState);
            chaseState.Initialize(moveMonster, attackState, idleState);
            attackState.Initialize(moveMonster, chaseState);
        }

        currentState = idleState;
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