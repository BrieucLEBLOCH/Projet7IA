using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationDistance;

    private Rigidbody2D rb2d;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void MoveTowardsThePlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            float speedFactor = Mathf.Clamp(1 - (distanceToPlayer / accelerationDistance), 0, 1);
            float adjustedSpeed = Mathf.Lerp(speed, maxSpeed, speedFactor);

            rb2d.MovePosition(rb2d.position + direction * adjustedSpeed * Time.fixedDeltaTime);
        }
    }
}

/*

public class MoveMonster : MonoBehaviour
{
    public Transform player;

    public float lastStateChangeTime = 0;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float accelerationDistance;
    [SerializeField] private float minimumDistanceToOtherMonster;

    private Rigidbody2D rb2d;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void MoveTowardsTarget(Transform target)
    {
        if (target != null && rb2d != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            float distanceToTarget = Vector2.Distance(transform.position, target.position);

            if (distanceToTarget > minimumDistanceToOtherMonster)
            {
                float speedFactor = Mathf.Clamp(1 - (distanceToTarget / accelerationDistance), 0, 1);
                float adjustedSpeed = Mathf.Lerp(speed, maxSpeed, speedFactor);

                rb2d.MovePosition(rb2d.position + direction * adjustedSpeed * Time.fixedDeltaTime);
            }
        }
    }

    public void MoveTowardsThePlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            float speedFactor = Mathf.Clamp(1 - (distanceToPlayer / accelerationDistance), 0, 1);
            float adjustedSpeed = Mathf.Lerp(speed, maxSpeed, speedFactor);

            rb2d.MovePosition(rb2d.position + direction * adjustedSpeed * Time.fixedDeltaTime);
        }
    }

    public Transform FindNearestMonsterGlobal()
    {
        MoveMonster[] allMonsters = FindObjectsOfType<MoveMonster>();
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

    public bool IsEnoughMonstersNearby(float range, int minimumMonsters)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        int monsterCount = 0;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Monster"))
            {
                monsterCount++;
            }
        }

        return monsterCount >= minimumMonsters;
    }

    public void NotifyNearbyMonsters(float range)
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);
        
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.gameObject.CompareTag("Monster") && hitCollider.gameObject != gameObject)
            {
                MoveMonster otherMonster = hitCollider.GetComponent<MoveMonster>();
                
                if (otherMonster != null)
                {
                    otherMonster.OnNotifiedForAttack();
                }
            }
        }
    }

    public void OnNotifiedForAttack()
    {
        StateManager stateManager = GetComponent<StateManager>();
        
        if (stateManager != null)
        {
            stateManager.SwitchToExplosionState();
        }
    }
}

*/