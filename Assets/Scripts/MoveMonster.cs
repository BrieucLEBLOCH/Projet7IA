using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster : MonoBehaviour
{
    private Player player;
    [SerializeField] private float moveSpeedMonster = 5f;
    private Rigidbody2D rb2d;


    private void Awake()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
        }
    }
}