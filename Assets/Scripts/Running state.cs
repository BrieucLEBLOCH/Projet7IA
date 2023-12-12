using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runningstate : State
{
    public Transform player;
    public Transform Zombie;
    public Chasestate chaseState;
    public bool safe_distance;
    public float moveSpeedMonster = 5f;
    private Rigidbody2D rb2d;

    public override State RunCurrentState()
    {
        distancePlayer();
        if (safe_distance)
            MoveFarFromPlayer();
        else 
            return chaseState;
        return this;
    }

    void MoveFarFromPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - Zombie.transform.position).normalized;
            Vector2 distance = player.transform.position - Zombie.transform.position;
            if (distance.magnitude < 2f)
                distance = distance * (-1);
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            Debug.Log("je fuis le joueur");
        }
    }

    void MoveForwardPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - Zombie.transform.position).normalized;
            Vector2 distance = player.transform.position - Zombie.transform.position;
            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            Debug.Log("je fuis le joueur");
        }
    }

    void distancePlayer()
    {
        if (player != null)
        {
            Vector2 distance = player.transform.position - Zombie.transform.position;
            if (distance.magnitude < 3f)
                safe_distance = false;
            else
                safe_distance = true;
        }
    }

}
