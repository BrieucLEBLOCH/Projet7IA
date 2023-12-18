using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.ShaderGraph.Internal.KeywordDependentCollection;
using static UnityEngine.GraphicsBuffer;

public class Tree : MonoBehaviour
{
    [SerializeField] private GameObject PrefabFireBall;
    private GameObject treeEnemies;
    private GameObject player;
    private bool canShoot = true, atRange = false;
    [SerializeField] private float fireBallSpeed = 5;
    private float distance;

    private void Start()
    {
        player = GameObject.Find("/Player");
        treeEnemies = GameObject.Find("/Enemies/Trees");

        foreach (Transform t in treeEnemies.GetComponentsInChildren<Transform>())
        {
            if (t != treeEnemies && t != gameObject.transform)
            {
                if (Vector3.Distance(t.position, gameObject.transform.position) < 3)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    void Update()
    {
        distance = Vector3.Distance(GameObject.Find("/Player").transform.position, gameObject.transform.position);
        if (distance > 25 && distance < 50)
        {
            atRange = false;
        }
        else if (distance >= 50)
        {
            Destroy(gameObject);
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
