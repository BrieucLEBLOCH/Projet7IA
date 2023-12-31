using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float maxHP = 10;
    [SerializeField] private int dmg = 1;
    [SerializeField] private GameObject XP;
    [SerializeField] private GameObject rangePrefab;
    [SerializeField] private GameObject healPrefab;
    private float HP = 1;
    private IEnumerator coroutine;
    Color color;


    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        HP = maxHP;
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }


    public void TakeDamages(int i)
    {
        HP -= i;
        if (HP <= 0)
        {
            int r = Random.Range(1, 50);
            Instantiate(XP, gameObject.transform.position, gameObject.transform.rotation);
            if (r == 1)
            {
                Instantiate(rangePrefab, gameObject.transform.position, gameObject.transform.rotation);
            }

            if (r == 2 || r == 3)
            {
                Instantiate(healPrefab, gameObject.transform.position, gameObject.transform.rotation);
            }
            Destroy(gameObject);
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        StartCoroutine(DamageTaken(0.5f));
    }

    private IEnumerator DamageTaken(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.GetComponent<SpriteRenderer>().color = color;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponentInParent<Player>().TakeDamage(dmg);
        }
    }
}
