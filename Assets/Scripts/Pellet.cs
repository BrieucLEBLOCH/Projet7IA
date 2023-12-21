using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private int dmg = 1;
    private float distance;

    private void Update()
    {
        distance = Vector3.Distance(GameObject.Find("/Player").transform.position, gameObject.transform.position);
        if (distance > 30)
        {
            Destroy(gameObject);
        }
    }

    public void SetPelletDmg(int i)
    {
        dmg = i;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Destroy(gameObject);
            collision.gameObject.GetComponentInParent<Enemy>().TakeDamages(dmg);
        }
    }
}
