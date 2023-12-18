using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject EnemiesObject;
    [SerializeField] private GameObject ZombieSpawner1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject enemies = Instantiate(ZombieSpawner1, gameObject.transform.position, gameObject.transform.rotation);
            enemies.transform.SetParent(EnemiesObject.transform);
        }
        //foreach (Transform enemy in enemies.transform)
        //{
        //    enemy.parent = null;
        //}
    }
}
