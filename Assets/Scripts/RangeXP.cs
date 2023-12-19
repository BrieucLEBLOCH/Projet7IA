using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class RangeXP : MonoBehaviour
{
    private GameObject grab;
    private Player player;
    private bool isFollowing = false;


    private void Start()
    {
        grab = GameObject.Find("Grab");
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
        if (collision.gameObject.tag == "Player")
        {
            grab.GetComponent<CircleCollider2D>().radius = 2f;
            StartCoroutine(ChangeRadiusAfterDelay(5.0f));
            gameObject.GetComponent<SpriteRenderer>().enabled = false;   
        }
    }

    private IEnumerator ChangeRadiusAfterDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        grab.GetComponent<CircleCollider2D>().radius = 0.5f;
        Destroy(gameObject);
    }
}
