using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chasestate : State
{
    public Move_F_Playerstate move_forward_player;
    public Run_F_Playerstatev2 running_from_player;

    public bool isInAttackRange;

    public Transform player;
    public Transform Zombie;
    private Rigidbody2D rb2d;
    public float moveSpeedMonster = 5f;
    public bool safe_distance;


    public override State RunCurrentState()
    {

        if (distancePlayer() < 4f)
        {
            return running_from_player;
        }
        else if (distancePlayer() >= 6f)
        {
            return move_forward_player;
        }
        else
            return this;
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
    /*
    void MoveForwardPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - Zombie.transform.position).normalized;
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            Debug.Log("je m approche du joueur");
        }

    }
*/


}
