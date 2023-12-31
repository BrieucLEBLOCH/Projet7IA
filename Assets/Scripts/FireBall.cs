using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    //test
    [SerializeField] private int dmg = 1;
    private float distance;

    private void Update()
    {
        distance = Vector3.Distance(GameObject.Find("/Player").transform.position, gameObject.transform.position);
        if (distance > 30)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponentInParent<Player>().TakeDamage(dmg);
        }
    }
}
