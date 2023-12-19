using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//state qui determine si le zombie fuie le joueur ou non
public class Running_stateZf : StateZf
{
    //liste des states necessaire
    public IdleStateZf idlestate;

    //joueur
    private GameObject player;

    private GameObject parentState;
    private Rigidbody2D rb2d;

    //stats zombie
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

    public override StateZf RunCurrentState()
    {
        //si le joueur est proche du zombie il fuit
        if (noclose())
        {
//            Debug.Log("je me casse");
            runningfromplayer();
            return this;
        }
        else //sinon on revient a idle
            return idlestate;
//        return this;//pas necessaire
    }

    bool noclose()
    {
        if (player != null)
        {
            //Vector2 direction = (player.transform.position - transform.position).normalized;
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
            Vector2 direction = (player.transform.position - transform.position).normalized * (-1);
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude <= range_running)
                rb2d.MovePosition(rb2d.position + (direction * moveSpeedMonster * Time.fixedDeltaTime));
        }
    }

}
