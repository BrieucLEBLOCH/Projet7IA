using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyState : State
{
    [SerializeField] private ChaseState chaseState;

    [SerializeField] private float rallyRadius;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, ChaseState chase)
    {
        moveMonster = mover;
        chaseState = chase;
    }

    public override State RunCurrentState()
    {
        if (MoveMonster.CountAllMonsters() < 2)
        {
            return chaseState;
        }

        if (moveMonster.IsEnoughMonstersNearby(rallyRadius, 2, 4))
        {
            return chaseState;
        }

        Transform nearestMonster = moveMonster.FindNearestMonsterGlobal();
        
        if (nearestMonster != null)
        {
            moveMonster.MoveTowardsTarget(nearestMonster);
        }

        return this;
    }
}