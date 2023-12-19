using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RallyState : KamikazeState
{
    [SerializeField] private ChaseState chaseState;

    [SerializeField] private float rallyRadius;

    private MoveKamikaze moveMonster;

    public void Initialize(MoveKamikaze mover, ChaseState chase)
    {
        moveMonster = mover;
        chaseState = chase;
    }

    public override KamikazeState RunCurrentState()
    {
        if (MoveKamikaze.CountAllMonsters() < 2)
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