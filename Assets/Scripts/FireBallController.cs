using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallController : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Test");

        if (collision.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    
    }
}
