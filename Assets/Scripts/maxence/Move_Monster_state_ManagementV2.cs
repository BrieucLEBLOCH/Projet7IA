using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Monster_state_ManagementV2 : MonoBehaviour
{
    public Transform player;
    public float moveSpeedMonster = 5f;
    private Rigidbody2D rb2d;

    public float range_attack = 5f;
    public float range_running = 3f;
    public float life = 100;
    public float CooldownAttack = 2f;
    public float CooldownMove = 1f;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move_or_running();
     
        //ou
        int i;

        i = choice_to_make();
        switch (i)
        {
            case 1:
                Debug.Log("je m enfuis");
                break;
            case 2:
                Debug.Log("je m approche");
                break;
            case 3:
                Debug.Log("j attaque");
                break;
        }
    }

    void move_or_running()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;

            if (distance.magnitude < range_running) //si le joueur est trop proche du zombie il fuit
            {
                rb2d.MovePosition(rb2d.position + ((direction * (-1)) * moveSpeedMonster * Time.fixedDeltaTime));
            }
            else if (distance.magnitude > range_running && distance.magnitude < range_attack) //si le joueur est loin du zombie ET en dehors de sa portee d'attaque alors on se rapproche
            {
                rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            }
            else //Loin du joueur mais a port�e d'attaque <==> on lnace une boule de feu
            {
                Debug.Log("J attaque");
            }
            // Debug.Log("Magnitude = " + distance.magnitude);
        }
    }

    int choice_to_make()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;

            if (distance.magnitude < range_running) //si le joueur est trop proche du zombie il fuit
                return 1;
            else if (distance.magnitude > range_running && distance.magnitude < range_attack) //si le joueur est loin du zombie ET en dehors de sa portee d'attaque alors on se rapproche
                return 2;
            else //Loin du joueur mais a port�e d'attaque <==> on lnace une boule de feu
                return 3;
        }
        return 0;
    }


    void move_to_player()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            rb2d.MovePosition(rb2d.position + ((direction * moveSpeedMonster * Time.fixedDeltaTime)));

        }
    }

    void running_from_player()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            Vector2 distance = player.transform.position - this.transform.position;
            rb2d.MovePosition(rb2d.position + ((direction * (-1)) * moveSpeedMonster * Time.fixedDeltaTime));
        }
    }

    void attack_player()
    {
        Debug.Log("J attaque");
    }


            //Au cas ou le zombie touche le joueur
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Le monstre a touch� le joueur !");
        }
    }
}