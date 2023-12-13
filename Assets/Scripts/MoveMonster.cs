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