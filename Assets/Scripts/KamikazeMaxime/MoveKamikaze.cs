using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveKamikaze : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float sprintSpeed;

    private Rigidbody2D rb2d;
    [HideInInspector] public Transform player;

    private void Start()
    {
        player = GameObject.Find("/Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public static int CountAllMonsters()
    {
        return FindObjectsOfType<MoveKamikaze>().Length;
    }

    public Transform FindNearestMonsterGlobal()
    {
        MoveKamikaze[] allMonsters = FindObjectsOfType<MoveKamikaze>();
        Transform nearestMonster = null;

        float closestDistance = float.MaxValue;

        foreach (var monster in allMonsters)
        {
            if (monster.gameObject != gameObject)
            {
                float distance = Vector2.Distance(transform.position, monster.transform.position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    nearestMonster = monster.transform;
                }
            }
        }

        return nearestMonster;
    }

    public bool IsEnoughMonstersNearby(float range, int minimumMonsters, int maximumMonsters)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        int monsterCount = 0;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Kamikaze"))
            {
                monsterCount++;
            }
        }

        return monsterCount >= minimumMonsters && monsterCount <= maximumMonsters;
    }

    public int CountNearbyMonsters(float range)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        int monsterCount = 0;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Kamikaze"))
            {
                monsterCount++;
            }
        }

        return monsterCount;
    }

    public void NotifyNearbyMonsters(float range)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Kamikaze") && hitCollider.gameObject != gameObject)
            {
                MoveKamikaze otherMonster = hitCollider.GetComponent<MoveKamikaze>();

                if (otherMonster != null)
                {
                    otherMonster.SwitchToExplosionState();
                }
            }
        }
    }

    public void SwitchToExplosionState()
    {
        ZombieKamikaze stateManager = GetComponent<ZombieKamikaze>();

        if (stateManager != null)
        {
            stateManager.SwitchToExplosionState();
        }
    }

    public void MoveTowardsTarget(Transform target)
    {
        if (target != null && target != transform && rb2d != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    public void MoveTowardsThePlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * sprintSpeed * Time.fixedDeltaTime);
        }
    }
}