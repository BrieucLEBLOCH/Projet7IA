using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shovel : MonoBehaviour
{
    [SerializeField]
    private int dmg = 2;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
        //GameObject shovelTextObject = GameObject.Find("ShovelTXT");
        //textATK = shovelTextObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //textATK.text = "ATK : " + dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "EnemyTag" || collision.gameObject.tag == "Kamikaze")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamages(dmg + player.GetDmgBonus());
        }
    }
}
