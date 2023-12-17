using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionState : State
{
    [SerializeField] private GameObject explosionEffect;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover)
    {
        moveMonster = mover;
    }

    public override State RunCurrentState()
    {
        Explode();
        Destroy(moveMonster.gameObject);
        return null;
    }

    private void Explode()
    {
        if (explosionEffect != null)
        {
            Instantiate(explosionEffect, moveMonster.transform.position, Quaternion.identity);
        }
    }
}