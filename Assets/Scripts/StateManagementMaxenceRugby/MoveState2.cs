using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//qui determine si on se rapproche ou attaque le joueur suivant la distance les séparant

public class MoveState2 : State2
{
    //liste des states necessaires
    public AttackState2 attackState;
    public IdleState2 idlestate;

    public bool isInAttackRange2;

    //joueur
    private GameObject player;

    //pour recuperer le rigidbody du parent parent
    private GameObject parentState;
    private Rigidbody2D rb2d;

    //stat du zombie
    public float moveSpeedMonster = 5f;
    public float range_attack = 5f;
    public float range_running = 3f;
    public float life = 100;
    public float CooldownAttack = 2f;
    public float CooldownMove = 1f;

    void Start()
    {
        player = GameObject.Find("/Player");
        parentState = this.transform.parent.gameObject;
        rb2d = parentState.GetComponentInParent<Rigidbody2D>();
    }

    public override State2 RunCurrentState()
    {
        //si on est a portée d'attaque
        if (isInAttackRange())
        {
            return attackState;
        }
        else if (canMoveCloser())//sinon si on est encore trop loin on se rapproche
        {
            move_to_player();
            return this;
        }
        else //sinon on retourne au state idle
        {
            return idlestate;
        }
    }

    bool canMoveCloser()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
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
            Vector2 direction = (player.transform.position - transform.position).normalized;
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
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            rb2d.MovePosition(rb2d.position + ((direction) * moveSpeedMonster * Time.fixedDeltaTime));
        }
    }
}

