using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMover : MonoBehaviour
{
    public Transform player;
    public float moveSpeedMonster = 2f;
    private Rigidbody2D rb2d;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    public void MoveTowardsPlayer()
    {
        if (player != null && rb2d != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
        }
    }
}