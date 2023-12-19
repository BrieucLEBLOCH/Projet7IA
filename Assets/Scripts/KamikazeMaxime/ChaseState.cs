using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : KamikazeState
{
    [SerializeField] private RallyState rallyState;
    [SerializeField] private ExplosionState explosionState;

    [SerializeField] private float explosionRange;

    private MoveKamikaze moveMonster;

    public void Initialize(MoveKamikaze mover, RallyState rally, ExplosionState explosion)
    {
        moveMonster = mover;
        rallyState = rally;
        explosionState = explosion;
    }

    public override KamikazeState RunCurrentState()
    {
        moveMonster.MoveTowardsThePlayer();

        float distanceToPlayer = Vector3.Distance(moveMonster.transform.position, moveMonster.player.position);

        if (distanceToPlayer <= explosionRange)
        {
            moveMonster.NotifyNearbyMonsters(explosionRange);
            return explosionState;
        }

        if (MoveKamikaze.CountAllMonsters() < 2)
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