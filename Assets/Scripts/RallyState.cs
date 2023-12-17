using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

public class RallyState : State
{
    [SerializeField] private ChaseState chaseState;

    [SerializeField] private float stateChangeCooldown;
    [SerializeField] private float rallyRadius;
    [SerializeField] private int minMonstersForAttack;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, ChaseState chase)
    {
        moveMonster = mover;
        chaseState = chase;
    }

    public override State RunCurrentState()
    {
        if (moveMonster.IsEnoughMonstersNearby(rallyRadius, 3) && Time.time > moveMonster.lastStateChangeTime + stateChangeCooldown)
        {
            moveMonster.lastStateChangeTime = Time.time;
            return chaseState;
        }
        else
        {
            Transform nearestMonster = moveMonster.FindNearestMonsterGlobal();
            
            if (nearestMonster != null)
            {
                moveMonster.MoveTowardsTarget(nearestMonster);
            }

            return this;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rallyRadius);
    }
}

*/