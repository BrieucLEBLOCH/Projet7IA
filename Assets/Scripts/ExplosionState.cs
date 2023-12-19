using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionState : State
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject explosionCollider;
    bool explosion = true;

    private MoveMonster moveMonster;

    public void Initialize(MoveMonster mover)
    {
        moveMonster = mover;
    }

    public override State RunCurrentState()
    {

        StartCoroutine(Explosion(0.5f));
        return null;
    }

    private IEnumerator Explosion(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        if (explosionEffect != null && explosion)
        {
            Instantiate(explosionEffect, moveMonster.transform.position, Quaternion.identity);
            explosion = false;
        }
        StartCoroutine(ExplosionCollider(1.0f));
    }

    private IEnumerator ExplosionCollider(float waitTime)
    {
        explosionCollider.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        explosionCollider.SetActive(false);
        Destroy(moveMonster.gameObject);
    }
}