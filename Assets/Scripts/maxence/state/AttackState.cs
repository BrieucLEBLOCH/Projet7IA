using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    //state
    public IdleState idlestate;

    private bool Had_Attacked = false;
    public float timeCoolDownAttack = 2;
    public float timeRemaining = 0;
    public override State RunCurrentState()
    {
        //s'il n'a pas encore attaqué 
        if (Had_Attacked == false)// && timeRemaining <= 0)
        {
            Debug.Log("j'attaque");
            Had_Attacked = true;
            timeRemaining = 2;
            return this;
        }
        else
        {
            if (timeRemaining <= 0)
            {
                Debug.Log("cooldown fini je retourne a idle");
                Had_Attacked = false;
                timeRemaining = timeCoolDownAttack;
                return idlestate;
            }
            else
            {
                Debug.Log("je suis en cooldown");
                return this;
            }
        }
        /*
        if (Had_Attacked == false)
        {
//            Time.deltaTime;
            if (timeRemaining <= 0)
            {
                Debug.Log("j'attaque");
                Had_Attacked = true;
                timeRemaining = 2;
                return this;
            }
            else
            {
                Debug.Log("je suis en cooldown");
                return this;
            }
            return this;
        }
        else if (Had_Attacked == true && timeRemaining <= 0)
        {
            Debug.Log("je sors du cooldown et je reppase a idle");
            Had_Attacked = false;
            return idlestate;
        }

        return this;*/
    }

    private void Update()
    {
        if (Had_Attacked == true)
            timeRemaining -= Time.deltaTime;
    }

}
