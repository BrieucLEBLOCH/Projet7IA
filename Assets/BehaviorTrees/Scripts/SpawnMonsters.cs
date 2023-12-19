using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class SpawnMonsters : ActionNode
{
    List<GameObject> spawnersPhase1 = new List<GameObject>();
    List<GameObject> spawnersPhase2 = new List<GameObject>();
    List<GameObject> spawnersPhase3 = new List<GameObject>();

    int bossPhase;
    protected override void OnStart() {
        
        //bossState = context.gameObject.GetComponent<BossState>();
        //bossState.phaseBossState = 1;
        bossPhase = context.gameObject.GetComponent<BossState>().GetPhase();
        //Debug.Log("cc"+ bossState.GetCooldown());
        foreach (Transform bossSpawner in context.transform.GetComponentsInChildren<Transform>())
        {
            if (bossSpawner.name == "SpawnersPhase1")
            {
                for (int i = 0; i < bossSpawner.childCount; i++)
                {
                    spawnersPhase1.Add(bossSpawner.GetChild(i).gameObject);
                    spawnersPhase2.Add(bossSpawner.GetChild(i).gameObject);
                    spawnersPhase3.Add(bossSpawner.GetChild(i).gameObject);
                }
            }
            else if(bossSpawner.name == "SpawnersPhase2")
            {
                for (int i = 0; i < bossSpawner.childCount; i++)
                {
                    spawnersPhase2.Add(bossSpawner.GetChild(i).gameObject);
                    spawnersPhase3.Add(bossSpawner.GetChild(i).gameObject);
                }
            }
            else
            {
                for (int i = 0; i < bossSpawner.childCount; i++)
                {
                    spawnersPhase3.Add(bossSpawner.GetChild(i).gameObject);
                }
            }
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        //string bossSpawnLevel = "spawnersPhase" + bossPhase;
        //Debug.Log(bossPhase);
        switch (bossPhase)
        {
            case 1:
                Debug.Log("phase 1");
                spawnMonsters(spawnersPhase1);
                break;
            case 2:
                Debug.Log("phase 2");
                spawnMonsters(spawnersPhase2);
                break; 
            case 3:
                Debug.Log("phase 3");
                spawnMonsters(spawnersPhase3);
                break;
        }
        
        return State.Success;
    }

    private void spawnMonsters(List<GameObject> spawners)
    {
        foreach (GameObject spawn in spawners)
        {
            GameObject zombie = context.gameObject.GetComponent<BossState>().zombieNormal;
            zombie.transform.position = spawn.transform.position;
            Instantiate(zombie);
            //Instantiate(spawn);
        }
        context.transform.GetComponent<SpawnCD>().InCooldown();
    }
}
