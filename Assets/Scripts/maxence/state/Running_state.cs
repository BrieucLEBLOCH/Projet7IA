using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Running_state : State
{
    public IdleState idlestate;

    //player
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
       // rb2d = GetComponent<Rigidbody2D>();
    }

    public override State RunCurrentState()
    {
        if (noclose())
        {
            Debug.Log("je me casse");
            runningfromplayer();
            return this;
        }
        else
            return idlestate;
        return this;
    }

    bool noclose()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude <= range_running)
                return true;
        }
        return false;
    }

    void runningfromplayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized * (-1);
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude <= range_running)
                rb2d.MovePosition(rb2d.position + (direction * moveSpeedMonster * Time.fixedDeltaTime));
        }
    }

}
