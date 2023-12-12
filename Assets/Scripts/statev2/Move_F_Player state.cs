using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//on se rapporche du joueur
public class Move_F_Playerstate : State
{
    public Transform player;
    public Transform Zombie;
    public Rigidbody2D rb2d;
    public float moveSpeedMonster = 5f;
    public bool safe_distance;
    public Chasestatev2 chasestatev2;
    public attackstatev2 attackstatev2;
    public override State RunCurrentState()
    {
        if (distancePlayer() > 5f)
        {

            //zombie doit se rapprocher
            Moving_forward_Player();
            return this;
        }
        else if (distancePlayer() < 5f && distancePlayer() > 3f)
        {
            return attackstatev2;
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

    void Moving_forward_Player()
    {
        if (player != null)
        {
            Vector3 direction = (player.position - Zombie.transform.position).normalized;
            Zombie.position = (Zombie.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
//            rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            Debug.Log("je m approche du joueur");
        }

    }
}
