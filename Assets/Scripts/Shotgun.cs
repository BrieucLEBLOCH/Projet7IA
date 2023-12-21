using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : MonoBehaviour
{
    [SerializeField] private int dmg = 2;
    private Player player;
    [SerializeField] GameObject bullet;
    private float pelletSpeed = 15;
    private int pelletCount = 5;
    private bool canShoot = true;
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

        if (canShoot)
        {
            Rigidbody2D pellet;
            for (int i = 0; i < pelletCount; i++)
            {
                pellet = Instantiate(bullet.GetComponent<Rigidbody2D>(), gameObject.transform.position, gameObject.transform.rotation);
                if (player.GetFlipped() ) { pellet.transform.Rotate(0, 0, 90); }
                else { pellet.transform.Rotate(0, 0, -90); }
                pellet.transform.Rotate(0, 0, Random.Range(-15, 15));
                pellet.velocity = pellet.transform.up * pelletSpeed;
                pellet.GetComponent<Pellet>().SetPelletDmg(dmg + player.GetDmgBonus());
            }
            canShoot = false;
            StartCoroutine(ShootCD(4 / player.GetWeaponSpeed()));
        }
    }

    private IEnumerator ShootCD (float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag")
        {
            Debug.Log("bite");
        }
    }
}
