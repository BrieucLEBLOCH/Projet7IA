using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField]
    private int dmg = 2;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetFlipped())
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            collision.gameObject.GetComponent<Dummy>().TakeDamages(dmg);
            Debug.Log("bite");
        }
    }
}
