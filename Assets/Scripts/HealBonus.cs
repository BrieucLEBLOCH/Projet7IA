using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBonus : MonoBehaviour
{
    private Player player;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (isFollowing)
        {
            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, 7 * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "GrabTag")
        {
            player = collision.gameObject.GetComponentInParent<Player>();
            isFollowing = true;
        }
        if (collision.gameObject.tag == "PlayerTag")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if(player.HP < player.maxHP)
            {
                player.HP += 2;
            }
            
        }
    }
}
