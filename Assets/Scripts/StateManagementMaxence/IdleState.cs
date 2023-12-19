using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleStateZf : StateZf
{
    //liste des differents states
    public MoveStateZf moveState;
    public AttackStateZf attackState;
    public Running_stateZf runningState;

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

    public override StateZf RunCurrentState()
    {
        int i;

        i = choice_to_make(); //suivant la distance séparant le zombie du joueur on selectionne le state correspondant
        //Debug.Log("test i = " + i);
        if (i == 1)//on fuit
        {
            return runningState;
        }
        else if (i == 2)//on attaque
        {
            return attackState;
        }
        else if (i == 3)//on se rapproche
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

            if (distance.magnitude < range_running) //si le joueur est trop proche du zombie il fuit
                return 1;
            else if (distance.magnitude > range_running && distance.magnitude <= range_attack) //si le joueur est loin du zombie ET en dehors de sa portee d'attaque alors on se rapproche
                return 2;
            else if (distance.magnitude > range_running && distance.magnitude > range_attack)
                return 3;
        }
        return 0;
    }
}
