using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionState : KamikazeState
{
    [SerializeField] private GameObject explosionEffect;
    [SerializeField] private GameObject explosionCollider;
    [SerializeField] private SpriteRenderer mobSprite;
    bool explosion = true;

    private MoveKamikaze moveMonster;

    public void Initialize(MoveKamikaze mover)
    {
        moveMonster = mover;
    }

    public override KamikazeState RunCurrentState()
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
        mobSprite.enabled = false;
        explosionCollider.SetActive(true);
        yield return new WaitForSeconds(waitTime);
        explosionCollider.SetActive(false);
        Destroy(moveMonster.gameObject);
    }
}