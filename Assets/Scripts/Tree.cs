using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject PrefabFireBall;
    private GameObject player;
    private bool canShoot = true;
    [SerializeField] private float fireBallSpeed = 5;

    private void Start()
    {
        player = GameObject.Find("/Player");
    }

    void Update()
    {
        if (canShoot)
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
