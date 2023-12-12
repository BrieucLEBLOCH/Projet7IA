using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlestatev2 : State
{
    public Chasestatev2 chaseState;
    public bool canSeethePlayer = false;
    public Transform player;
    public Transform Zombie;

    public override State RunCurrentState()
    {
        Isplayernexttome();
        if (canSeethePlayer)
        {
            return chaseState;
        }
        else
            return this;
    }

    void Isplayernexttome()
    {
        if (player != null)
        {
            Vector2 distance = player.transform.position - Zombie.transform.position;
            if (distance.magnitude < 6f)
                canSeethePlayer = true;
            else
                canSeethePlayer = false;
        }

    }
}
