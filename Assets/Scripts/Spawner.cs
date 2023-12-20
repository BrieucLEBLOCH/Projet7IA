using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool canSpawn = true;

    private Transform zombiesTransform;
    private Transform treesTransform;
    [SerializeField] private GameObject enemiesParent;

    [SerializeField] private GameObject zombieSpawner1;
    private float zombie1CD;
    private bool zombie1Spawn = true;

    [SerializeField] private GameObject zombieSpawner2;
    private float zombie2CD;
    private bool zombie2Spawn = true;

    [SerializeField] private GameObject treeSpawner1;
    private float tree1CD;
    private bool tree1Spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        zombie1CD = Random.Range(1.0f, 5.0f);
        zombie2CD = Random.Range(1.0f, 3.0f);
        tree1CD = Random.Range(3.0f, 5.0f);

        foreach (Transform t in enemiesParent.GetComponentsInChildren<Transform>())
        {
            if (t.name == "Zombies")
            {
                zombiesTransform = t;
            }
            if (t.name == "Trees")
            {
                treesTransform = t;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!canSpawn) return;

        if (zombie1Spawn)
        {
            StartCoroutine(SpawnZombie1(zombie1CD));
            zombie1Spawn = false;
        }
        if (zombie2Spawn)
        {
            StartCoroutine(SpawnZombie2(zombie2CD));
            zombie2Spawn = false;
        }
        if (tree1Spawn)
        {
            StartCoroutine(SpawnTree1(tree1CD));
            tree1Spawn = false;
        }
    }

    private IEnumerator SpawnZombie1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(zombieSpawner1, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(zombiesTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            enemy.SetParent(zombiesTransform);
        }
        Destroy(enemies);
        zombie1Spawn = true;
        zombie1CD = Random.Range(10.0f, 15.0f);
    }

    private IEnumerator SpawnZombie2(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(zombieSpawner2, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(zombiesTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            enemy.SetParent(zombiesTransform);
        }
        Destroy(enemies);
        zombie2Spawn = true;
        zombie2CD = Random.Range(5.0f, 10.0f);
    }

    private IEnumerator SpawnTree1(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        GameObject enemies = Instantiate(treeSpawner1, gameObject.transform.position, gameObject.transform.rotation);
        enemies.transform.SetParent(treesTransform);
        foreach (Transform enemy in enemies.GetComponentsInChildren<Transform>())
        {
            enemy.SetParent(treesTransform);
        }
        Destroy(enemies);
        tree1Spawn = true;
        tree1CD = Random.Range(12.0f, 17.0f);
    }
}
