using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveMonster2 : MonoBehaviour
{
    public Transform player;
    public float moveSpeedMonster = 5f;
    private Rigidbody2D rb2d;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveTowardsPlayer();
    }

    void MoveTowardsPlayer()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized * (-1);
            Vector2 distance = player.transform.position - this.transform.position;
            if (distance.magnitude < 3f)
                  rb2d.MovePosition(rb2d.position + direction * moveSpeedMonster * Time.fixedDeltaTime);
            else if (distance.magnitude > 3f && distance.magnitude < 7f)
            {
//                Debug.Log("Je fais rien");

            }
            else
                rb2d.MovePosition(rb2d.position + -direction * moveSpeedMonster * Time.fixedDeltaTime);
           // Debug.Log("Magnitude = " + distance.magnitude);
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Le monstre a touché le joueur !");
        }
    }

}