using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Transform zombiesTransform;
    private Transform treesTransform;
    private Transform kamikazeTransform;
    private Transform zombieFBTransform;
    private Transform zombieRTransform;
    [SerializeField] private GameObject enemiesParent;

    [SerializeField] private GameObject zombieSpawner;
    private float zombieCD;
    private bool zombieSpawn = true;

    [SerializeField] private GameObject zombieFBSpawner;
    private float zombieFBCD;
    private bool zombieFBSpawn = true;

    [SerializeField] private GameObject zombieRSpawner;
    private float zombieRCD;
    private bool zombieRSpawn = true;

    [SerializeField] private GameObject kamikazeSpawner;
    private float kamikazeCD;
    private bool kamikazeSpawn = true;

    [SerializeField] private GameObject treeSpawner;
    private float treeCD;
    private bool treeSpawn = true;

    // Start is called before the first frame update
    void Start()
    {
        zombieCD = 1.0f;
        kamikazeCD = 10.0f;
        treeCD = 3.0f;
        zombieFBCD = 3.0f;
        zombieRCD = 8.0f;

        foreach (Transform t in enemiesParent.GetComponentsInChildren<Transform>())
        {
            if (t.name == "Zombies")
            {
                zombiesTransform = t;
            }
            if (t.name == "ZombiesR")
            {
                zombieRTransform = t;
            }
            if (t.name == "ZombiesFB")
            {
                zombieFBTransform = t;
            }
            if (t.name == "Trees")
            {
                treesTransform = t;
            }
            if (t.name == "Kamikazes")
            {
                kamikazeTransform = t;
            }
        }
    }

    void Update()
    {
        if (zombieSpawn)
        {
            StartCoroutine(SpawnZombie(zombieCD));
            zombieSpawn = false;
        }
        if (zombieFBSpawn)
        {
            StartCoroutine(SpawnZombieFB(zombieFBCD));
            zombieFBSpawn = false;
        }
        if (zombieRSpawn)
        {
            StartCoroutine(SpawnZombieR(zombieRCD));
            zombieRSpawn = false;
        }
        if (kamikazeSpawn)
        {
            StartCoroutine(SpawnKamikaze(kamikazeCD));
            kamikazeSpawn = false;
        }
        if (treeSpawn)
        {
            StartCoroutine(SpawnTree(treeCD));
            treeSpawn = false;
        }
    }

    private IEnumerator SpawnZombie(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(zombieSpawner, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(zombiesTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            enemy.SetParent(zombiesTransform);
        }
        Destroy(enemies);
        zombieSpawn = true;
        zombieCD = Random.Range(10.0f, 15.0f);
    }

    private IEnumerator SpawnZombieFB(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(zombieFBSpawner, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(zombieFBTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            if (enemy.parent == enemies.transform)
            {
                enemy.SetParent(zombieFBTransform);
            }
        }
        Destroy(enemies);
        zombieFBSpawn = true;
        zombieFBCD = Random.Range(20.0f, 30.0f);
    }

    private IEnumerator SpawnZombieR(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(zombieRSpawner, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(zombieRTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            if (enemy.parent == enemies.transform)
            {
                enemy.SetParent(zombieRTransform);
            }
        }
        Destroy(enemies);
        zombieRSpawn = true;
        zombieRCD = Random.Range(20.0f, 30.0f);
    }

    private IEnumerator SpawnKamikaze(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(kamikazeSpawner, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(kamikazeTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>(false))
        {
            if (enemy.parent == enemies.transform)
            {
                enemy.SetParent(kamikazeTransform);
            }
        }
        Destroy(enemies);
        kamikazeSpawn = true;
        kamikazeCD = Random.Range(25.0f, 40.0f);
    }

    private IEnumerator SpawnTree(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(treeSpawner, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(treesTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            enemy.SetParent(treesTransform);
        }
        Destroy(enemies);
        treeSpawn = true;
        treeCD = Random.Range(12.0f, 17.0f);
    }
}
