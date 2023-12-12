using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP : MonoBehaviour
{
    private Player player;
    bool isFollowing = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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
            player.AddXP();
            Destroy(gameObject);
        }
    }
}
