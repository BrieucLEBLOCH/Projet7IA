using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public Transform player;

    public bool isIdle;

    [SerializeField] private float speed;

    private Rigidbody2D rb2d;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (isIdle)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }

    public void MoveTowardsThePlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
            isIdle = false;
        }
    }
}

/*

public class MoveMonster : MonoBehaviour
{
    public Transform player;
    public float speed;
    public float detectionRange;
    public float attackRange;
    public float attackInterval;
    public bool isIdle;

    private Rigidbody2D rb2d;
    [SerializeField] private MonsterState currentState;
    private float lastAttackTime;

    private enum MonsterState
    {
        Idle,
        Chase,
        Attack,
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
        currentState = MonsterState.Idle;
        isIdle = true;
    }

    private void Update()
    {
        UpdateState();
    }

    private void FixedUpdate()
    {
        if (currentState == MonsterState.Chase)
        {
            MoveTowardsThePlayer();
        }


        if (isIdle)
        {
            FreezeMovement();
        }
        else
        {
            UnfreezeMovement();
        }
    }

    private void UpdateState()
    {
        switch (currentState)
        {
        case MonsterState.Idle:
            HandleIdleState();
            break;
        case MonsterState.Chase:
            HandleChaseState();
            break;
        case MonsterState.Attack:
            HandleAttackState();
            break;
        }
    }

    private void HandleIdleState()
    {
        isIdle = true;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            currentState = MonsterState.Chase;
        }
    }

    private void HandleChaseState()
    {
        isIdle = false;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= attackRange)
        {
            currentState = MonsterState.Attack;
        }
        else if (distanceToPlayer > detectionRange)
        {
            currentState = MonsterState.Idle;
        }
    }

    private void HandleAttackState()
    {
        isIdle = false;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer > attackRange)
        {
            currentState = MonsterState.Chase;
        }
        else if (Time.time - lastAttackTime > attackInterval)
        {
            AttackPlayer();
            lastAttackTime = Time.time;
        }
    }

    private void MoveTowardsThePlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * speed * Time.fixedDeltaTime);
        }
    }

    private void FreezeMovement()
    {
        rb2d.velocity = Vector2.zero;
        rb2d.angularVelocity = 0;
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void UnfreezeMovement()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void AttackPlayer()
    {
        Debug.Log("J'attaque !");
    }

    private void OnDrawGizmosSelected()
    {
        // Dessine un cercle bleu autour du monstre représentant la zone de détection pour passer à l'état Chase
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRange);

        // Dessine un cercle rouge autour du monstre représentant la zone de détection pour passer à l'état Attack
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}

*/