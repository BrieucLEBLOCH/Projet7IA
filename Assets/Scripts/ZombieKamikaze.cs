using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieKamikaze : MonoBehaviour
{
    private State currentState;
    [SerializeField] private ChaseState chaseState;
    [SerializeField] private RallyState rallyState;
    [SerializeField] private ExplosionState explosionState;

    private MoveMonster moveMonster;

    private void Start()
    {
        moveMonster = GetComponent<MoveMonster>();

        if (chaseState != null && rallyState != null && explosionState != null)
        {
            chaseState.Initialize(moveMonster, rallyState, explosionState);
            rallyState.Initialize(moveMonster, chaseState);
            explosionState.Initialize(moveMonster);
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

    public void SwitchToExplosionState()
    {
        if (explosionState != null)
        {
            currentState = explosionState;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("bite");
        }
    }
}