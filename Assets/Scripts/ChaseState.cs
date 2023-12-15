using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState attackState;

    [SerializeField] private float attackRange;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, AttackState attack)
    {
        moveMonster = mover;
        attackState = attack;
    }

    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= attackRange)
        {
            return attackState;
        }
        else
        {
            moveMonster.MoveTowardsThePlayer();
            return this;
        }
    }
}