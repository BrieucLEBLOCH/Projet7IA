using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    private MonsterMover monsterMover;
    public float attackCooldown = 2f;
    private float lastAttackTime;
    public float chaseRange = 10f;

    public void Initialize(MonsterMover mover)
    {
        monsterMover = mover;
    }

    public override State RunCurrentState()
    {
        if (Time.time - lastAttackTime > attackCooldown)
        {
            Debug.Log("J'ai attaqué !");
            lastAttackTime = Time.time;
        }

        if (monsterMover == null || monsterMover.player == null)
        {
            return this;
        }

        if (Vector3.Distance(transform.position, monsterMover.player.position) > chaseRange)
        {
            return monsterMover.GetComponent<ChaseState>();
        }

        return this;
    }
}