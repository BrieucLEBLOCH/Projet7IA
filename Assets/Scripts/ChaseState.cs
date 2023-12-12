using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    private MonsterMover monsterMover;
    public AttackState attackState;
    public IdleState idleState;
    public float attackRange = 1f;
    public float loseInterestRange = 15f;

    public void Initialize(MonsterMover mover)
    {
        monsterMover = mover;
        
        if (attackState != null)
        {
            attackState.Initialize(mover);
        }
    }

    public override State RunCurrentState()
    {
        if (monsterMover == null || monsterMover.player == null)
        {
            return this;
        }

        if (Vector2.Distance(transform.position, monsterMover.player.position) <= attackRange)
        {
            return attackState;
        }

        return this;
    }
}