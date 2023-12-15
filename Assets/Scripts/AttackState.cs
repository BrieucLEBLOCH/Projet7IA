using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    [SerializeField] private ChaseState chaseState;

    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    [SerializeField] private float attackInterval;
    
    private float lastAttackTime;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, ChaseState chase)
    {
        moveMonster = mover;
        chaseState = chase;
    }

    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= attackRange)
        {
            if (Time.time - lastAttackTime > attackInterval)
            {
                AttackPlayer();
                lastAttackTime = Time.time;
            }
            
            return chaseState;
        }

        return chaseState;
    }

    private void AttackPlayer()
    {
        Debug.Log("J'attaque !");
    }
}