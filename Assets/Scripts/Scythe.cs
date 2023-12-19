using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scythe : MonoBehaviour
{
    private float rotateSpeed = -500f;
    private Player player;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private int dmg;
    private Vector3 direction;
    private bool isReturning = false;

    private void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
        direction = player.GetFlipped() ? -player.transform.right : player.transform.right;
    }
    void Update()
    {
        transform.Rotate(Vector3.forward * rotateSpeed * Time.deltaTime);
        if (Vector3.Distance(gameObject.transform.position, player.transform.position) > 10)
        {
            isReturning = true;
        }
        if (isReturning)
        {
            direction = player.transform.position - gameObject.transform.position;
        }
        GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "EnemyTag" || collision.gameObject.tag == "Kamikaze")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamages(dmg);
        }
    }

}
