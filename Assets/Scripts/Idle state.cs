using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idlestate : State
{
    public Chasestate chaseState;
    public bool canSeethePlayer;
    public Transform player;
    public Transform Zombie;

    public override State RunCurrentState()
    {
        IsPlayerNextToMe();
        if (canSeethePlayer)
        {
            return chaseState;
        }
        else
            return this;
    }


    void IsPlayerNextToMe()
    {
        if (player != null)
        {
            Vector2 distance = player.transform.position - Zombie.transform.position;
            if (distance.magnitude < 4f)
                canSeethePlayer = true;
            else
                canSeethePlayer = false;
        }

    }
}
