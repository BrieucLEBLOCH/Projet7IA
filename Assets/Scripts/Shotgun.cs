using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int dmg = 2;
    private Player player;
    [SerializeField] GameObject bullet;
    float pelletSpeed = 1500;
    int pelletCount = 5;
    float spreadFactor = 0.01f;
    float fireRate = 0.5f;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Rigidbody pellet;
            for (int i = 0; i < pelletCount; i++)
            {
                pellet = Instantiate(bullet.GetComponent<Rigidbody>(), gameObject.transform.position, gameObject.transform.rotation);
                pellet.transform.Rotate(0, 0, Random.Range(-100, 100));
                pellet.velocity = pellet.transform.up * pelletSpeed * Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Debug.Log("bite");
        }
    }
}
