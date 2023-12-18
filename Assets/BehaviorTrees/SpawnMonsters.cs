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
        bossPhase = context.gameObject.GetComponent<BossState>().GetPhase();
        //string bossSpawnLevel = "spawnersPhase" + bossPhase;

        switch (bossPhase)
        {
            case 1:
                foreach (GameObject spawn in spawnersPhase1)
                {

                }
                break;
            case 2:
                foreach (GameObject spawn in spawnersPhase1)
                {

                }
                break; 
            case 3:
                foreach (GameObject spawn in spawnersPhase1)
                {

                }
                break;
        }
        
        return State.Success;
    }

    private void spawnMonsters(List<GameObject> spawners)
    {
        foreach (GameObject spawn in spawners)
        {
            
            //Instantiate(spawn);
        }
    }
}
