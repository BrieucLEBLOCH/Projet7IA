using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TreeMonster : MonoBehaviour
{
    [SerializeField] private GameObject PrefabFireBall;
    private GameObject player;
    private bool canShoot = true, atRange = false;
    [SerializeField] private float fireBallSpeed = 5;
    private float distance;

    private void Start()
    {
        player = GameObject.Find("/Player");
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("/Player").transform.position, gameObject.transform.position);
        if (distance > 15)
        {
            atRange = false;
        }
        else
        {
            atRange = true;
        }
        if (canShoot && atRange)
        {
            GameObject newFireBall = Instantiate(PrefabFireBall, gameObject.transform.position, gameObject.transform.rotation);
            newFireBall.transform.up = player.transform.position - newFireBall.transform.position;
            newFireBall.GetComponent<Rigidbody2D>().velocity = newFireBall.transform.up * fireBallSpeed;
            canShoot = false;
            StartCoroutine(ShootFireBall(2));
        }
    }

    private IEnumerator ShootFireBall(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        canShoot = true;
    }
}
