using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State
{
    //state
    public AttackState attackState;
    public IdleState idlestate;

    public bool isInAttackRange2;
    public Transform player;
    public float moveSpeedMonster = 5f;
    public Rigidbody2D rb2d;

    public float range_attack = 5f;
    public float range_running = 3f;
    public float life = 100;
    public float CooldownAttack = 2f;
    public float CooldownMove = 1f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //rb2d = GetComponent<Rigidbody2D>();
    }

    public override State RunCurrentState()
    {

        if (isInAttackRange())
        {
            return attackState;
        }
        else if (canMoveCloser())
        {
            move_to_player();
            return this;
        }
        else
        {
            return idlestate;
        }
    }

    bool canMoveCloser()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude > range_running)
                return true;
        }
        return false;
    }
    bool isInAttackRange()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude < range_attack && distance.magnitude > (range_attack-0.5))
                return true;
        }
        return false;
    }
    void move_to_player()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            rb2d.MovePosition(rb2d.position + ((direction * moveSpeedMonster * Time.fixedDeltaTime)));
        }
    }
}

