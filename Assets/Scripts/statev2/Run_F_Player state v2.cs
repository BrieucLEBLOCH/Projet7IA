using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//on cherche a fuir le joueur (se placer a x metre de lui)
public class Run_F_Playerstatev2 : State
{
    public Transform player;
    public Transform Zombie;
    private Rigidbody2D rb2d;
    public float moveSpeedMonster = 5f;
    public bool safe_distance;
    public Chasestatev2 chasestatev2;
    public override State RunCurrentState()
    {
        if (distancePlayer() < 4f)
        {
            //zombie doit fuir
            Running_From_Player();
            return this;
        }
        else
            return chasestatev2; //sinon on revient au stade chasev2
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

    void Running_From_Player()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - Zombie.transform.position).normalized * (-1);
            Zombie.position = (Zombie.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            //rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            Debug.Log("je fuie le joueur");
        }

    }
}
