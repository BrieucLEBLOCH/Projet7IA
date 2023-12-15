using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    public Transform player;

    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float minDistanceForMaxSpeed;

    [SerializeField] private float attackRange;

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
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            float adjustedSpeed = CalculateSpeed(distanceToPlayer);

            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * adjustedSpeed * Time.fixedDeltaTime);
        }
    }

    private float CalculateSpeed(float distance)
    {
        float distanceFactor = Mathf.Clamp((minDistanceForMaxSpeed - distance) / minDistanceForMaxSpeed, 0, 1);
        float speedFactor = Mathf.Pow(distanceFactor, 2);
        return Mathf.Lerp(speed, maxSpeed, speedFactor);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}