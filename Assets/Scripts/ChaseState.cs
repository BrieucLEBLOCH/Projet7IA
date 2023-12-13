using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private AttackState attackState;
    [SerializeField] private IdleState idleState;

    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, AttackState attack, IdleState idle)
    {
        moveMonster = mover;
        attackState = attack;
        idleState = idle;
    }

    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= attackRange)
        {
            return attackState;
        }
        else if (distanceToPlayer <= detectionRange)
        {
            moveMonster.MoveTowardsThePlayer();
            return this;
        }
        else
        {
            return idleState;
        }
    }
}