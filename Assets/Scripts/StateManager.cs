using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    public State currentState;
    private MonsterMover monsterMover;
    public ChaseState chaseState;
    public AttackState attackState;

    void Start()
    {
        monsterMover = GetComponent<MonsterMover>();

        if (chaseState != null)
        {
            chaseState.Initialize(monsterMover);
        }

        if (attackState != null)
        {
            attackState.Initialize(monsterMover);
        }

        currentState = chaseState;
    }

    void Update()
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