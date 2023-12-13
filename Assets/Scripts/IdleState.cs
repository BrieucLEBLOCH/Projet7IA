using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    [SerializeField] private ChaseState chaseState;

    [SerializeField] private float detectionRange;
    [SerializeField] private float attackRange;
    
    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, ChaseState chase)
    {
        moveMonster = mover;
        chaseState = chase;
    }

    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= detectionRange)
        {
            return chaseState;
        }

        moveMonster.isIdle = true;

        return this;
    }
    
    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle bleu autour du monstre repr�sentant la zone de d�tection pour passer � l'�tat Chase
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Dessine un cercle rouge autour du monstre repr�sentant la zone de d�tection pour passer � l'�tat Attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}