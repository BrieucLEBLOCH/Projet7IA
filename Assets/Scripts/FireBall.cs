using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public GameObject PrefabFireBall;
    public Transform player;
    public Transform firePoint;
    public float fireBallSpeed = 3f;
    public float fireRate = 1f;
    private float nextFireTime = 0f; 

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            ShootFireBall();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void ShootFireBall()
    {
        GameObject newFireBall = Instantiate(PrefabFireBall, firePoint.position, firePoint.rotation);
        Vector2 fireBallDirection = (player.position - firePoint.position).normalized;
        newFireBall.GetComponent<Rigidbody2D>().velocity = fireBallDirection * fireBallSpeed;
    }
}
