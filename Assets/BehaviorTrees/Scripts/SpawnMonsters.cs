using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SpawnMonsters : ActionNode
{
    List<GameObject> spawners = new List<GameObject>();

    protected override void OnStart() {
        
        //bossState = context.gameObject.GetComponent<BossState>();
        //bossState.phaseBossState = 1;
        //Debug.Log("cc"+ bossState.GetCooldown());
        foreach (Transform bossSpawner in context.transform.GetComponentsInChildren<Transform>())
        {
            if (bossSpawner.name == "Spawners")
            {
                for (int i = 0; i < bossSpawner.childCount; i++)
                {
                    spawners.Add(bossSpawner.GetChild(i).gameObject);
                }
            }
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        spawnMonsters(spawners);
        return State.Success;
    }

    private void spawnMonsters(List<GameObject> spawners)
    {
        foreach (GameObject spawn in spawners)
        {
            GameObject zombie = context.gameObject.GetComponent<BossState>().zombieNormal;
            zombie.transform.position = spawn.transform.position;
            zombie.tag = "BossMob";
            zombie.AddComponent<CircleCollider2D>();
            Instantiate(zombie);
            context.gameObject.GetComponent<BossState>().zombies.Add(zombie);
            Debug.Log(zombie.transform);
            //Instantiate(spawn);
        }
        context.transform.GetComponent<SpawnCD>().InCooldown();
    }
}
