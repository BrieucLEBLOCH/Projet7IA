using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : State
{
    [SerializeField] private RallyState rallyState;
    [SerializeField] private ExplosionState explosionState;

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
        moveMonster.MoveTowardsThePlayer();

        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= explosionRange)
        {
            moveMonster.NotifyNearbyMonsters(explosionRange);
            return explosionState;
        }

        if (MoveMonster.CountAllMonsters() < 2)
        {
            return this;
        }

        if (moveMonster.IsEnoughMonstersNearby(explosionRange, 2, 4))
        {
            return this;
        }

        return rallyState;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRange);
    }
}