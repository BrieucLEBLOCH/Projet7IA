using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ShotScythe : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    private Player player;

    private float timeBetweenShots = 2f;
    private float timeSinceLastShot = 0f;


    private void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Time.time - timeSinceLastShot > timeBetweenShots)
        {
            Shoot();
            timeSinceLastShot = Time.time;
        }
    }

    private void Shoot()
    {
        Vector3 spawnPosition = player.transform.position;
        if (player.GetFlipped())
        {
            spawnPosition.x -= 1.0f;
        }
        else
        {
            spawnPosition.x += 1.0f; 
        }  

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
