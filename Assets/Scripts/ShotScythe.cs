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

    private bool canShoot = true;


    private void Start()
    {
        player = GameObject.Find("/Player").GetComponent<Player>();
    }

    void Update()
    {
        if (canShoot)
        {
            Shoot();
            canShoot = false;
            StartCoroutine(Cd(2/player.GetWeaponSpeed()));
        }
    }

    private IEnumerator Cd(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }

    private void Shoot()
    {
        Vector3 spawnPosition = gameObject.transform.position;
        if (player.GetFlipped())
        {
            spawnPosition.x -= 2.0f;
        }
        else
        {
            spawnPosition.x += 2.0f; 
        }

        GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
    }
}
