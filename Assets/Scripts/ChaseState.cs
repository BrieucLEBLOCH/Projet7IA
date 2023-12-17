using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private ExplosionState explosionState;

    [SerializeField] private float explosionRange;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, ExplosionState explosion)
    {
        moveMonster = mover;
        explosionState = explosion;
    }

    public override State RunCurrentState()
    {
        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= explosionRange)
        {
            return explosionState;
        }
        else
        {
            moveMonster.MoveTowardsThePlayer();
            return this;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}

/*

public class ChaseState : State
{
    [SerializeField] private RallyState rallyState;
    [SerializeField] private ExplosionState explosionState;

    [SerializeField] private float stateChangeCooldown;
    [SerializeField] private float explosionRange;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover, RallyState rally, ExplosionState explosion)
    {
        moveMonster = mover;
        rallyState = rally;
        explosionState = explosion;
    }

    public override State RunCurrentState()
    {
        if (moveMonster.IsEnoughMonstersNearby(explosionRange, 3))
        {
            float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

            if (distanceToPlayer <= explosionRange)
            {
                moveMonster.NotifyNearbyMonsters(explosionRange);
                return explosionState;
            }
            else
            {
                moveMonster.MoveTowardsThePlayer();
            }
        }
        else if (Time.time > moveMonster.lastStateChangeTime + stateChangeCooldown)
        {
            moveMonster.lastStateChangeTime = Time.time;
            return rallyState;
        }

        return moveMonster.IsEnoughMonstersNearby(explosionRange, 3) ? this : rallyState;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}

*/