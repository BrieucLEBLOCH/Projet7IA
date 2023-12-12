using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasestatev2 : State
{
    public Run_F_Playerstatev2 running_from_player;
    public Move_F_Playerstate move_forward_player;

    public Transform player;
    public Transform Zombie;
    private Rigidbody2D rb2d;
    public float moveSpeedMonster = 5f;
    public bool safe_distance;


    public override State RunCurrentState()
    {
        if (distancePlayer() < 2f)
        {
            return running_from_player;//state on fuit le joueur
        }
        else if (distancePlayer() >= 5f)
        {
            return move_forward_player;//state on se rapproche du joueur
        }
        else
            return this; //sinon le zombie reste sur place
    }
    float distancePlayer()
    {
        if (player != null)
        {
            Vector2 distance = player.transform.position - Zombie.transform.position;
            return (distance.magnitude);
        }
        return 0f;
    }
}
