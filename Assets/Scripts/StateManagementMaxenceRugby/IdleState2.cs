using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState2 : State2
{
    //liste des differents states
    public MoveState2 moveState;
    public AttackState2 attackState;

    //Player
    private GameObject player;

    private GameObject parentState;
    private Rigidbody2D rb2d;

    //Parametre zombie_vomi
    public float range_attack = 6f;
    public float range_running = 3f;
    public float life = 100;
    public float CooldownAttack = 2f;
    public float CooldownMove = 1f;
    public float moveSpeedMonster = 5f;

    private void Start()
    {
        player = GameObject.Find("/Player");
        parentState = this.transform.parent.gameObject;
        rb2d = parentState.GetComponentInParent<Rigidbody2D>();
    }

    public override State2 RunCurrentState()
    {
        int i;

        i = choice_to_make(); //suivant la distance séparant le zombie du joueur on selectionne le state correspondant
        Debug.Log("test i = " + i);
        /*if (i == 1)//on fuit
        {
            return runningState;
        }
        else*/ if (i == 1)//on attaque
        {
            return attackState;
        }
        else if (i == 2)//on se rapproche
        {
            return moveState;
        }
        else//rien
            return this;
    }

    int choice_to_make()
    {
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;

            if (distance.magnitude <= range_attack) //si le joueur est a portée d'attaque du joueur
                return 1;
            else
                return 2;
        }
        return 0;
    }
}