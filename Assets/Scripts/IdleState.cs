using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public ChaseState chaseState;
    public float detectionRange = 10f;
    private MonsterMover monsterMover;

    public void Initialize(MonsterMover mover)
    {
        monsterMover = mover;
    }

    public override State RunCurrentState()
    {
        if (monsterMover == null || monsterMover.player == null)
        {
            return this;
        }

        if (Vector3.Distance(transform.position, monsterMover.player.position) <= detectionRange)
        {
            return chaseState;
        }

        return this;
    }
}