using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField]
    private float maxHP = 10;
    private float HP = 1;
    private IEnumerator coroutine;
    Color color;
    // Start is called before the first frame update
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        HP = maxHP;
        color = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamages(int i)
    {
        HP -= i;
        if (HP <= 0)
        {
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
}
